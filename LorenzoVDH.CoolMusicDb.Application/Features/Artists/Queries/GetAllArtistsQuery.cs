using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Artists.Queries
{
    public class GetAllArtistsQuery : IRequest<List<Artist>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllArtistsQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
