using BandApi.Entities;
using BandApi.Helpers;
using System;
using System.Collections.Generic;

namespace BandApi.Repositories
{
    public interface IBandAlbumRepository
    {
        IEnumerable<Album> GetAlbums(Guid bandId);
        Album GetAlbum(Guid albumId);

        void AddAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Guid albumId);

        IEnumerable<Band> GetBands();
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        public IEnumerable<Band> GetBands(BandsResourceParameters parameters);
        void AddBand(Band and);
        void AddBands(IEnumerable<Band> bands);
        void UpdateBand(Band band);
        void DeleteBand(Guid bandId);
        bool IsBandExists(Guid bandId);
        bool IsAlbumExists(Guid albumId);
        bool Save();
    }
}
