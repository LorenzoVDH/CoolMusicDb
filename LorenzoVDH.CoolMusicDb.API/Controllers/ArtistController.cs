using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;
using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Commands;

namespace LorenzoVDH.CoolMusicDb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        //Read ... todo: implement pagination 
        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            List<Artist> artists = await _mediator.Send(new GetAllArtistsQuery());

            if (artists.Count == 0)
                return NoContent();

            List<ArtistOverviewDTO> artistDTOs = _mapper.Map<List<ArtistOverviewDTO>>(artists);

            return Ok(artistDTOs);
        } 

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistCreateDTO artist)
        {
            try {
                if (artist == null)
                    return BadRequest("No artist provided"); 

                var newArtist = _mapper.Map<Artist>(artist); 

                await _mediator.Send(new CreateArtistCommand(newArtist)); 

                return Ok($"Artist '{newArtist.ArtistName}' created successfully.");
            } 
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the artist: {ex.Message}");
            }
        }

        //Update

        //Delete

    }
}
