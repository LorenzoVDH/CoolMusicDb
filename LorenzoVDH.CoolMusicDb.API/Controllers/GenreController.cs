using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs.Genres;
using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LorenzoVDH.CoolMusicDb.API.Controllers;

[ApiController]
[Route("Genres")]
public class GenreController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<AlbumController> _logger;

    public GenreController(IMediator mediator, IMapper mapper, ILogger<AlbumController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllGenres()
    {
        List<Genre> genres = await _mediator.Send(new GetAllGenresQuery());

        if (genres.Count == 0)
            return NoContent();

        List<GenreOverviewDTO> genreDTOs = _mapper.Map<List<GenreOverviewDTO>>(genres);

        return Ok(genreDTOs);
    }

    [HttpGet("Simplified")]
    public async Task<IActionResult> GetAllGenresSimplified()
    {
        List<Genre> genres = await _mediator.Send(new GetAllGenresWithoutHierarchyQuery());

        if (genres.Count == 0)
            return NoContent();

        List<GenreSimpleDTO> genreDTOs = _mapper.Map<List<GenreSimpleDTO>>(genres);

        return Ok(genreDTOs);
    }

    [HttpGet("{genreId}")]
    public async Task<IActionResult> GetGenreById(int genreId)
    {
        Genre? genre = await _mediator.Send(new GetGenreByIdQuery(genreId));

        if (genre == null)
            return NoContent();

        GenreOverviewDTO genreDTO = _mapper.Map<GenreOverviewDTO>(genre);

        return Ok(genreDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] GenreCreateDTO genre)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (genre == null)
                return BadRequest("No genre provided");

            var genreToBeAdded = _mapper.Map<Genre>(genre);
            var addedGenre = await _mediator.Send(new CreateGenreCommand(genreToBeAdded));
            var dto = _mapper.Map<GenreDetailDTO>(addedGenre);

            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the genre: {ex.Message}");
        }
    }

    // [HttpPost("Parent/{parentId}/Child/{childId}")]
    // public async Task<IActionResult> CreateGenreParentChildRelationship(int parentId, int childId)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         await _mediator.Send(new CreateGenreParentChildRelationshipCommand(parentId, childId));

    //         return Ok($"Genre Parent-Child relationship between parent {parentId} and child {childId} created succesfully!");
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"An error occurred while creating the genre relationship: {ex.Message}");
    //     }
    // }

    [HttpDelete("{genreId}")]
    public async Task<IActionResult> DeleteGenre(int genreId)
    {
        try
        {
            await _mediator.Send(new DeleteGenreCommand(genreId));

            return Ok($"Genre {genreId} was deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while deleting genre {genreId}: {ex.Message}");
        }
    }

    // [HttpDelete("Parent/{parentId}/Child/{childId}")]
    // public async Task<IActionResult> DeleteGenreParentChildRelationship(int parentId, int childId)
    // {
    //     try
    //     {
    //         await _mediator.Send(new DeleteGenreParentChildRelationshipCommand(parentId, childId));

    //         return Ok($"Genre relationship between genre {parentId} and genre {childId} has been deleted");
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"An error occured while deleting the parent/child relationship between genres {parentId} and {childId}: {ex.Message}");
    //     }
    // }

    [HttpPut("{genreId}/SubGenres")]
    public async Task<IActionResult> SetChildrenForGenre(int genreId, [FromBody] List<int> subgenreIds)
    {
        try
        {
            await _mediator.Send(new SetParentChildRelationshipsForGenreCommand(genreId, subgenreIds));

            return Ok($"The children/subgenres have been set for genre {genreId}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while setting the parent/child relationship for genre {genreId}: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGenre(GenreUpdateDTO genreInDto)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var genreToUpdate = _mapper.Map<Genre>(genreInDto);
            var updatedGenre = await _mediator.Send(new UpdateGenreCommand(genreToUpdate));
            var genreOutDto = _mapper.Map<GenreUpdateDTO>(updatedGenre);

            return Ok(genreOutDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while updating the genre: {ex.Message}");
        }
    }

    [HttpPost("{genreId}/AddPopularArtist/{popularArtistId}")]
    public async Task<IActionResult> AddPopularArtistToGenre(int popularArtistId, int genreId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _mediator.Send(new AddPopularArtistToGenreCommand(popularArtistId, genreId));

            return Ok($"Popular artist with id {popularArtistId} has been succesfully added to Genre with id {genreId}!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while trying to add the popular artist with id {popularArtistId} " +
                                   $"to Genre with id {genreId}: {ex.Message}");
        }
    }

    [HttpDelete("{genreId}/RemovePopularArtist/{popularArtistId}")]
    public async Task<IActionResult> RemovePopularArtistFromGenre(int popularArtistId, int genreId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _mediator.Send(new RemovePopularArtistFromGenreCommand(popularArtistId, genreId));

            return Ok($"Popular artist with id {popularArtistId} has been succesfully removed from Genre with id {genreId}!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while trying to remove the popular artist with id {popularArtistId} " +
                                   $"from Genre with id {genreId}: {ex.Message}");
        }
    }
}
