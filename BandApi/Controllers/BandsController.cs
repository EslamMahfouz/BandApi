using AutoMapper;
using BandApi.Entities;
using BandApi.Helpers;
using BandApi.Models;
using BandApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repository;
        private readonly IMapper _mapper;

        public BandsController(IBandAlbumRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BandDto>> GetBands([FromQuery] BandsResourceParameters parameters)
        {
            var bands = _repository.GetBands(parameters);
            var bandsDto = _mapper.Map<IEnumerable<BandDto>>(bands);
            return Ok(bandsDto);
        }

        [HttpGet("{bandId}", Name = "GetBand")]
        public IActionResult GetBand(Guid bandId)
        {
            var band = _repository.GetBand(bandId);
            if (band == null)
                return NotFound();
            return Ok(band);
        }

        [HttpGet("({ids})", Name = "GetBandsCollection")]
        public IActionResult GetBandCollection([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            var bands = _repository.GetBands(ids);
            if (ids.Count() != bands.Count())
                return NotFound();
            return Ok(_mapper.Map<IEnumerable<BandDto>>(bands));
        }

        [HttpPost]
        public ActionResult<BandDto> CreateBand(CreateBandDto bandDto)
        {
            var band = _mapper.Map<Band>(bandDto);
            _repository.AddBand(band);
            _repository.Save();
            var bandToReturn = _mapper.Map<BandDto>(band);
            return CreatedAtRoute("GetBand", new { bandId = band.Id }, bandToReturn);
        }

        [HttpPost("collection")]
        public ActionResult<IEnumerable<BandDto>> CreateBands(IEnumerable<CreateBandDto> bandDtos)
        {
            var bands = _mapper.Map<IEnumerable<Band>>(bandDtos);
            _repository.AddBands(bands);
            _repository.Save();

            var ids = string.Join(",", bands.Select(b => b.Id));
            var bandCollectionToReturn = _mapper.Map<IEnumerable<BandDto>>(bands);
            return CreatedAtRoute("GetBandsCollection", new { ids = ids }, bandCollectionToReturn);
        }

        [HttpOptions]
        public IActionResult GetBandsOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,HEAD,OPTIONS");
            return Ok();
        }

        [HttpDelete("{bandId}")]
        public ActionResult DeleteBand(Guid bandId)
        {
            if (bandId == null)
                throw new ArgumentNullException(nameof(bandId));

            var band = _repository.GetBand(bandId);
            if (band == null)
                return NotFound();

            _repository.DeleteBand(bandId);
            _repository.Save();
            return NoContent();
        }
    }
}
