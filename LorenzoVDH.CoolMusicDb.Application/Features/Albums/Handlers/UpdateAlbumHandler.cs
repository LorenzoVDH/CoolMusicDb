using LorenzoVDH.CoolMusicDb.Application.Features.Albums.Commands;
using LorenzoVDH.CoolMusicDb.Application.Interfaces.Repositories;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;
using MediatR;

namespace LorenzoVDH.CoolMusicDb.Application.Features.Albums.Handlers;

public class UpdateAlbumHandler : IRequestHandler<UpdateAlbumCommand, Album>
{
    private readonly IAlbumRepository _albumRepository;
    public UpdateAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    public async Task<Album> Handle(UpdateAlbumCommand command, CancellationToken cancellationToken)
    {
        //First update the album 
        await _albumRepository.UpdateAlbumAsync(command.Album);
        //Retrieve the same album after the update in order to include all the artists 
        return command.Album;
    }
}

