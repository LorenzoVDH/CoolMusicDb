using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;
using LorenzoVDH.CoolMusicDb.API.DTOs.Artists;
using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;

namespace LorenzoVDH.CoolMusicDb.API.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ArtistController> _logger;

        public ArtistController(IMediator mediator, IMapper mapper, ILogger<ArtistController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("Artists")]
        public async Task<IActionResult> GetAllArtists(int pageIndex = 0, int pageSize = 5)
        {
            List<Artist> artists = await _mediator.Send(new GetAllArtistsQuery(pageIndex, pageSize));
            var totalArtists = await _mediator.Send(new GetTotalArtistCountQuery());

            if (artists.Count == 0)
                return NoContent();

            List<ArtistOverviewDTO> artistDTOs = _mapper.Map<List<ArtistOverviewDTO>>(artists);

            var returnObject = new
            {
                Artists = artistDTOs,
                Total = totalArtists
            };

            return Ok(returnObject);
        }

        [HttpGet("Artist/{artistId}")]
        public async Task<IActionResult> GetArtistByIdAsync(int artistId)
        {
            var artist = await _mediator.Send(new GetArtistByIdQuery(artistId));

            if (artist == null)
                return NoContent();

            var artistDTO = _mapper.Map<ArtistDetailDTO>(artist);

            return Ok(artistDTO);
        }

        //Create
        [HttpPost("Artist")]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistCreateDTO artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var artistToCreate = _mapper.Map<Artist>(artist);
                var createdArtist = await _mediator.Send(new CreateArtistCommand(artistToCreate));
                var dto = _mapper.Map<ArtistDetailDTO>(createdArtist);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the artist: {ex.Message}");
            }
        }

        [HttpPost("Artist/{artistId}/Album/{albumId}")]
        public async Task<IActionResult> AddAlbumToArtist(int albumId, int artistId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _mediator.Send(new CreateAlbumArtistRelationshipCommand(albumId, artistId));

                return Ok($"Album {albumId} has been added to artist {artistId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while creating the Artist-Album relationship: {ex.Message}");
            }
        }

        //Update

        //Delete
        [HttpDelete("Artist/{artistId}")]
        public async Task<IActionResult> DeleteArtist(int artistId)
        {
            try
            {
                await _mediator.Send(new DeleteArtistCommand(artistId));

                return Ok($"Artist {artistId} has been successfully deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while removing the Artist: {ex.Message}");
            }
        }

        [HttpDelete("Artist/{artistId}/Album/{albumId}")]
        public async Task<IActionResult> RemoveAlbumFromArtist(int artistId, int albumId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _mediator.Send(new RemoveArtistFromAlbumCommand(artistId, albumId));

                return Ok($"Album {albumId} has been removed from artist {artistId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while removing the Album from the Artist: {ex.Message}");
            }
        }

    }
}
