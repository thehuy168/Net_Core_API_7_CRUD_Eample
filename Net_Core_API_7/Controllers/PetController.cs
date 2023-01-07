using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Core_API_7.Services;
using Net_Core_API_7.ViewModels;

namespace Net_Core_API_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }


        [HttpGet("GetAll")]
        public async Task< IActionResult> GetAll()
        {
            var data = await _petService.GetAll();
            return Ok(data);
        }

        [HttpGet("{petId}")]
        public async Task< IActionResult> GetById(int petId)
        {
            var pet = await _petService.GetById(petId);
            if (pet == null) return BadRequest($"Can not find  pet with Id:{petId}");
            return Ok(pet);
        }
        [HttpPost("PetCreat")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult>PetCreat([ FromForm]PetCreatVm vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var petId = await _petService.PetCreat(vm);
            if (petId == 0) return BadRequest();
            var pet = await _petService.GetById(petId);
            return Ok(pet);
        }
        [HttpPut("petid")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PetUpdate( [FromForm] PetUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            var affectedResult = await _petService.PetUpdate(vm);
            if (affectedResult == 0) return BadRequest();
            return Ok();
        }
        [HttpDelete("{petId}")]
        public async Task <IActionResult>Delete(int id)
        {
            var affected = await _petService.PetDelete(id);
            if(affected == 0) return BadRequest();
            return Ok();
        }

    }
}
