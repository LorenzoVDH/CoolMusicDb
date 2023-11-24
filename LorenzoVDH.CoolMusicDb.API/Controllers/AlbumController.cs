using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LorenzoVDH.CoolMusicDb.API.Controllers;

[ApiController]
[Route("[controller]")]
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

    // [HttpGet]
    // public async Task<IActionResult> GetAlbumsByArtistId(int artistId)
    // {
    //     return Ok();
    // }
}
