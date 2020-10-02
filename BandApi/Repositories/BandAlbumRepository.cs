using BandApi.DContexts;
using BandApi.Entities;
using BandApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BandApi.Repositories
{
    public class BandAlbumRepository : IBandAlbumRepository
    {
        private readonly BandAlbumContext _context;

        public BandAlbumRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Albums

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            return _context.Albums.Where(a => a.BandId == bandId).OrderBy(a => a.Title).ToList();
        }

        public Album GetAlbum(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));
            return _context.Albums.Find(albumId);
        }

        public void AddAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (album.BandId == Guid.Empty)
                throw new ArgumentNullException(nameof(album.BandId));
            _context.Albums.Add(album);
        }

        public void UpdateAlbum(Album album)
        {

        }

        public void DeleteAlbum(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));
            var album = _context.Albums.Find(albumId);
            _context.Albums.Remove(album);
        }
        public bool IsAlbumExists(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));
            return _context.Albums.Any(a => a.Id == albumId);
        }
        #endregion

        #region Bands

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands.OrderBy(a => a.Name).ToList();
        }
        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if (bandIds == null)
                throw new ArgumentNullException(nameof(bandIds));
            return _context.Bands.Where(a => bandIds.Contains(a.Id)).OrderBy(a => a.Name).ToList();
        }

        public IEnumerable<Band> GetBands(BandsResourceParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));
            if (string.IsNullOrWhiteSpace(parameters.MainGenre) && string.IsNullOrWhiteSpace(parameters.SearchQuery))
                return GetBands();

            var collection = _context.Bands as IQueryable<Band>;
            if (!string.IsNullOrWhiteSpace(parameters.MainGenre))
                collection = collection.Where(a => a.MainGenre == parameters.MainGenre.Trim());

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
                collection = collection.Where(a => a.Name.Contains(parameters.SearchQuery));

            return collection.ToList();
        }

        public Band GetBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            return _context.Bands.Find(bandId);

        }




        public void AddBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));
            _context.Bands.Add(band);
        }

        public void AddBands(IEnumerable<Band> bands)
        {
            if (bands == null)
                throw new ArgumentNullException(nameof(bands));
            _context.Bands.AddRange(bands);
        }

        public void UpdateBand(Band band)
        {
            throw new NotImplementedException();
        }

        public void DeleteBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            var band = _context.Bands.Find(bandId);
            _context.Bands.Remove(band);
        }

        public bool IsBandExists(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));
            return _context.Bands.Any(a => a.Id == bandId);
        }

        #endregion

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
