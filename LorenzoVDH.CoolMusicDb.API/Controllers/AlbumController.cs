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
[Route("Albums")]
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

    [HttpGet]
    public async Task<IActionResult> GetAllAlbums()
    {
        List<Album> albums = await _mediator.Send(new GetAllAlbumsQuery());

        if (albums.Count == 0)
            return NoContent();

        List<AlbumOverviewDTO> albumDTOs = _mapper.Map<List<AlbumOverviewDTO>>(albums);

        return Ok(albumDTOs);
    }

    [HttpGet("ByArtist")]
    public async Task<IActionResult> GetAlbumsByArtist(int artistId)
    {
        List<Album> albums = await _mediator.Send(new GetAlbumsByArtistQuery(artistId));

        if (albums.Count == 0)
            return NoContent();

        var albumDTOs = _mapper.Map<List<AlbumOverviewDTO>>(albums);

        return Ok(albumDTOs);
    }

    [HttpPost]
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

            var newAlbum = _mapper.Map<Album>(album);

            await _mediator.Send(new CreateAlbumCommand(newAlbum));

            return Ok($"Album '{newAlbum.Name}' created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating the album: {ex.Message}");
        }
    }
}
