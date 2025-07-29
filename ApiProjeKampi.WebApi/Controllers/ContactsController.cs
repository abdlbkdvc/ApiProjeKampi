using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            Contact contact = new Contact();
            contact.Email = dto.Email;
            contact.Address = dto.Address;
            contact.Phone = dto.Phone;
            contact.MapLocation = dto.MapLocation;
            contact.OpenHours = dto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);

            _context.Remove(value);
            _context.SaveChanges();

            return Ok("Silme işlemi başarılı.");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var contactDb = _context.Contacts.Find(dto.ContactId);
            contactDb.Email = dto.Email;
            contactDb.Address = dto.Address;
            contactDb.Phone = dto.Phone;
            contactDb.MapLocation = dto.MapLocation;
            contactDb.OpenHours = dto.OpenHours;

            _context.SaveChanges();

            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
