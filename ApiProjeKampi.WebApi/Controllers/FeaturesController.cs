using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {

            var values = _context.Features.ToList();
            var mappedValues = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            var mappedValue = _mapper.Map<Feature>(dto);
            _context.Add(mappedValue);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            var mappedValue = _mapper.Map<GetByIdFeatureDto>(value);
            return Ok(mappedValue);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            var mappedValue = _mapper.Map<Feature>(dto);
            _context.Update(mappedValue);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
