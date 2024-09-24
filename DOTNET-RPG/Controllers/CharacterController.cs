
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetListOfCharacter()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}",Name ="GetSingle")]
        public async Task<ActionResult<ServiceResponse<Character>>> Get(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost(Name = "AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character character)
        {
            return Ok(await _characterService.AddCharacters(character));
        }
    }
}
