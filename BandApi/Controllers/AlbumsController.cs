using AutoMapper;
using BandApi.Entities;
using BandApi.Models;
using BandApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BandApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repository;
        private readonly IMapper _mapper;

        public AlbumsController(IBandAlbumRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("albums/{bandId}")]
        public ActionResult<IEnumerable<AlbumDto>> GetAlbums(Guid bandId)
        {
            if (!_repository.IsBandExists(bandId))
                return NotFound();
            var albums = _repository.GetAlbums(bandId);
            return Ok(_mapper.Map<IEnumerable<AlbumDto>>(albums));
        }

        [HttpGet("album/{albumId}", Name = "GetAlbum")]
        public ActionResult<AlbumDto> GetAlbum(Guid albumId)
        {
            var album = _repository.GetAlbum(albumId);
            if (album == null)
                return NotFound();
            return Ok(_mapper.Map<AlbumDto>(album));
        }

        [HttpPost("albums")]
        public ActionResult<AlbumDto> CreateAlbum(CreateAlbumDto albumDto)
        {

            if (!_repository.IsBandExists(albumDto.BandId))
                return NotFound();
            var album = _mapper.Map<Album>(albumDto);
            _repository.AddAlbum(album);
            _repository.Save();

            var albumToReturn = _mapper.Map<AlbumDto>(album);

            return CreatedAtRoute("GetAlbum", new { albumId = albumToReturn.Id }, albumToReturn);
        }

        [HttpPut("Albums")]
        public ActionResult UpdateAlbum(UpdateAlbumDto albumDto)
        {
            var albumFromRepo = _repository.GetAlbum(albumDto.Id);
            if (albumFromRepo == null)
                return NotFound();
            _mapper.Map(albumDto, albumFromRepo);
            _repository.UpdateAlbum(albumFromRepo);
            _repository.Save();
            return NoContent();
        }

        [HttpPatch("Albums/{albumId}")]
        public ActionResult PartiallyUpdateAlbum(Guid albumId, JsonPatchDocument<UpdateAlbumDto> patchDocument)
        {
            if (albumId == null)
                throw new ArgumentNullException(nameof(albumId));

            var albumFromRepo = _repository.GetAlbum(albumId);
            if (albumFromRepo == null)
                return NotFound();

            var albumToPatch = _mapper.Map<UpdateAlbumDto>(albumFromRepo);
            patchDocument.ApplyTo(albumToPatch, ModelState);
            if (!TryValidateModel(albumToPatch))
                return ValidationProblem(ModelState);
            _mapper.Map(albumToPatch, albumFromRepo);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("albums/{albumId}")]
        public ActionResult DeleteAlbum(Guid albumId)
        {
            if (albumId == null)
                throw new ArgumentNullException(nameof(albumId));

            var albumFromRepo = _repository.GetAlbum(albumId);
            if (albumFromRepo == null)
                return NotFound();

            _repository.DeleteAlbum(albumId);
            _repository.Save();
            return NoContent();
        }
    }
}
