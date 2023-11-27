using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs.Genres;
using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Commands;
using LorenzoVDH.CoolMusicDb.Application.Features.Genres.Queries;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
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
    public async Task<IActionResult> GetMainGenres()
    {
        List<Genre> genres = await _mediator.Send(new GetMainGenresQuery());

        if (genres.Count == 0)
            return NoContent();

        List<GenreOverviewDTO> genreDTOs = _mapper.Map<List<GenreOverviewDTO>>(genres);

        return Ok(genreDTOs);
    }

    [HttpGet("SubGenresByParent")]
    public async Task<IActionResult> GetSubGenresByParentId(int genreId)
    {
        List<Genre> genres = await _mediator.Send(new GetSubGenresByParentQuery(genreId));

        if (genres.Count == 0)
            return NoContent();

        List<GenreOverviewDTO> genreDTOs = _mapper.Map<List<GenreOverviewDTO>>(genres);

        return Ok(genreDTOs);
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

            var newGenre = _mapper.Map<Genre>(genre);

            await _mediator.Send(new CreateGenreCommand(newGenre));

            return Ok($"Genre '{newGenre.Name}' created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the genre: {ex.Message}");
        }
    }

    [HttpPost("ParentChildRelationship")]
    public async Task<IActionResult> CreateGenreParentChildRelationship([FromBody] GenreCreateParentChildRelationshipDTO genreParentChildRelationship)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (genreParentChildRelationship == null)
                return BadRequest("No Genre Parent-Child relationship provided");

            await _mediator.Send(new CreateGenreParentChildRelationshipCommand(genreParentChildRelationship.ParentId,
                                                                               genreParentChildRelationship.ChildId));

            return Ok($"Genre Parent-Child relationship between parent {genreParentChildRelationship.ParentId}" +
                      $"and child {genreParentChildRelationship.ChildId} created succesfully!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the genre relationship: {ex.Message}");
        }
    }
}
