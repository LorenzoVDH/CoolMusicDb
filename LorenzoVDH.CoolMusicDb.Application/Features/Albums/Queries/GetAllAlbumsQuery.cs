using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Queries
{
    public class GetAllAlbumsQuery : IRequest<List<Album>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllAlbumsQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}