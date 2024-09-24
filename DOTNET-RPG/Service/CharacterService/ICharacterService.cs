using DOTNET_RPG.Models;

namespace DOTNET_RPG.Service.CharacterService
{
    
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();

        Task<ServiceResponse<Character>> GetCharacterById(int id);    

        Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter);
    }
}
