using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries;

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

        [HttpGet]
        public async Task<ActionResult> GetAllArtists()
        {
            List<Artist> artists = await _mediator.Send(new GetAllArtistsQuery());

            if (artists.Count == 0)
                return NoContent();

            List<ArtistOverviewDTO> artistDTOs = _mapper.Map<List<ArtistOverviewDTO>>(artists);

            return Ok(artistDTOs);
        } 
    }
}
