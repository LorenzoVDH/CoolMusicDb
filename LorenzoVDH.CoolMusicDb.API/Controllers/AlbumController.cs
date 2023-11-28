using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.API.DTOs.Albums;
using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LorenzoVDH.CoolMusicDb.API.Controllers;

[ApiController]
// [Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<AlbumController> _logger;

    public AlbumController(IMediator mediator, IMapper mapper, ILogger<AlbumController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("Albums")]
    public async Task<IActionResult> GetAllAlbums(int pageIndex = 0, int pageSize = 5)
    {
        List<Album> albums = await _mediator.Send(new GetAllAlbumsQuery(pageIndex, pageSize));
        var totalAlbums = await _mediator.Send(new GetTotalAlbumCountQuery());

        if (albums.Count == 0)
            return NoContent();

        List<AlbumOverviewDTO> albumDTOs = _mapper.Map<List<AlbumOverviewDTO>>(albums);

        var returnObject = new
        {
            Albums = albumDTOs,
            Total = totalAlbums
        };

        return Ok(returnObject);
    }

    [HttpGet("Album/{albumId}")]
    public async Task<IActionResult> GetAlbumById(int albumId)
    {
        var album = await _mediator.Send(new GetAlbumByIdQuery(albumId));

        if (album == null)
            return NoContent();

        var albumDTO = _mapper.Map<AlbumDetailDTO>(album);

        return Ok(albumDTO);
    }

    [HttpGet("Albums/ByArtist/{artistId}")]
    public async Task<IActionResult> GetAlbumsByArtist(int artistId)
    {
        List<Album> albums = await _mediator.Send(new GetAlbumsByArtistQuery(artistId));

        if (albums.Count == 0)
            return NoContent();

        var albumDTOs = _mapper.Map<List<AlbumOverviewDTO>>(albums);

        return Ok(albumDTOs);
    }

    [HttpPost("Album")]
    public async Task<IActionResult> CreateAlbum(AlbumCreateDTO album)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            if (album == null)
                return BadRequest("No album provided");

            var albumToCreate = _mapper.Map<Album>(album);
            var createdAlbum = await _mediator.Send(new CreateAlbumCommand(albumToCreate));
            var dto = _mapper.Map<AlbumDetailDTO>(createdAlbum);

            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the album: {ex.Message}");
        }
    }

    [HttpPost("Album/{albumId}/Artist/{artistId}")]
    public async Task<IActionResult> AddArtistToAlbum(int albumId, int artistId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _mediator.Send(new CreateAlbumArtistRelationshipCommand(albumId, artistId));

            return Ok($"Artist {artistId} has been added to the album {albumId}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while creating the Album-Artist relationship: {ex.Message}");
        }
    }

    [HttpDelete("Album/{albumId}/Artist/{artistId}")]
    public async Task<IActionResult> RemoveArtistFromAlbum(int albumId, int artistId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _mediator.Send(new RemoveArtistFromAlbumCommand(artistId, albumId));

            return Ok($"Artist {artistId} has been removed from the album {albumId}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while removing the Artist from the Album: {ex.Message}");
        }
    }

    [HttpPut("Album")]
    public async Task<IActionResult> UpdateAlbum(AlbumUpdateDTO albumInDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var albumToUpdate = _mapper.Map<Album>(albumInDto);
            var updatedAlbum = await _mediator.Send(new UpdateAlbumCommand(albumToUpdate));
            var albumOutDto = _mapper.Map<AlbumDetailDTO>(updatedAlbum);

            return Ok(albumOutDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while updating the album: {ex.Message}");
        }
    }

    [HttpDelete("Album/{albumId}")]
    public async Task<IActionResult> DeleteAlbum(int albumId)
    {
        try
        {
            await _mediator.Send(new DeleteAlbumCommand(albumId));
            return Ok($"Album {albumId} has been removed.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occured while deleting album #{ex.Message} ");
        }
    }
}
