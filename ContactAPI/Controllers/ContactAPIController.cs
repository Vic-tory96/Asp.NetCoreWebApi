
using AutoMapper;
using ContactAPIRepository;
using DataAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelAPI;
using ModelDTO;
using System.Text.Json;
using System.Net;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace ContactAPI.Controllers
{
    [Route("api/ ContactAPI")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        public APIResponse _response;
        private readonly IContactRepository _dbContact;
        private readonly IMapper _mapper;
        private readonly ContactContext _context;
        public ContactAPIController(IContactRepository dbContact, IMapper mapper, ContactContext context)
        {
            _dbContact = dbContact;
            _mapper = mapper;
            _response = new();
            _context = context;
        }

      
        [HttpGet("all")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> GetContacts(int pageSize = 0 , int pageNumber = 1)
        {
            try
            {
                IEnumerable<Contact> contactList = await _dbContact.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);

                //just newly implemented...take it out if it disrupt the code

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize};

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<ContactDTO>>(contactList);
                _response.StatusCode =  HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("{id:int}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      //  [ResponseCache(Duration = 30, Location =ResponseCacheLocation.None, NoStore =true)]

        public async Task<ActionResult<APIResponse>> GetContact(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var contact = await _dbContact.GetAsync(u => u.Id == id);

                if (contact == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
              

                _response.Result = _mapper.Map<ContactDTO>(contact);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateContact([FromBody]ContactCreateDTO createDTO)
        {
            try
            {
                if (await _dbContact.GetAsync(u => u.MobilePhone == createDTO.MobilePhone) != null)
                {
                    ModelState.AddModelError("CustomError", "Contact Already Exist!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Contact contact = _mapper.Map<Contact>(createDTO);

                await _dbContact.CreateAsync(contact);
                _response.Result = _mapper.Map<ContactDTO>(contact);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetContact", new { id = contact.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name = "DeleteContact")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteContact(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var contact = await _dbContact.GetAsync(u => u.Id == id);
                if (contact == null)
                {
                    return NotFound();
                }
                await _dbContact.RemoveAsync(contact);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut("{id:int}", Name = "UpdateContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateContact(int id, [FromBody] ContactUpdateDTO updateDTO)
        {
            try
            {

                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Contact model = _mapper.Map<Contact>(updateDTO);

                await _dbContact.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Contact>>> SearchContact(string name)
        {
            var search = await _dbContact.SearchContactAsync(name);
            if (search == null)
            {
                return NotFound(search);
            }
            return Ok(search);
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialContact(int id, JsonPatchDocument<ContactUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var contact = await _dbContact.GetAsync(u => u.Id == id, tracked: false);

            ContactUpdateDTO contactDTO = _mapper.Map<ContactUpdateDTO>(contact);

            if (contact == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(contactDTO, ModelState);
            Contact model = _mapper.Map<Contact>(contactDTO);

            await _dbContact.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        [HttpPatch("photos")]
        public async Task<IActionResult> UploadPhoto2(IFormFile file, int id)
        {
            
            var contact =  _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound("Contact to upload picture to not available");
            }
            if (file == null || file.Length == 0)
            {
                return BadRequest(new
                {
                    Status = "No Image Uploaded"
                });
            }
            var cloudinary = new Cloudinary(new Account("dxyglxgo4", "163751844341583", "F7T162uX1VnD94YVllWFrBRfdU4"));
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                PublicId = $"{id}"
            };
            var result = cloudinary.Upload(uploadParams);
            if (result == null)
            {
                return BadRequest(new
                {
                    Status = "Image not upload successfully"
                });
            }
            contact.ImageUrl = result.Url.ToString();
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                PublicId = result.PublicId,
                Url = result.SecureUrl.ToString(),
                Status = "Uploaded Successfully"
            });
        }

    }
}
