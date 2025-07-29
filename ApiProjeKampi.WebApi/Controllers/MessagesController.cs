using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            var mappedValues = _mapper.Map<List<ResultMessageDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            var mappedValue = _mapper.Map<Message>(dto);
            _context.Add(mappedValue);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            var mappedValue = _mapper.Map<GetByIdMessageDto>(value);
            return Ok(mappedValue);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto dto)
        {
            var mappedValue = _mapper.Map<Message>(dto);
            _context.Update(mappedValue);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
