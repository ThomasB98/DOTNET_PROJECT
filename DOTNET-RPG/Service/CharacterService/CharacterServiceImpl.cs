
using DOTNET_RPG.Models;

namespace DOTNET_RPG.Service.CharacterService
{
    public class CharacterServiceImpl : ICharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character { Id = 1, Name = "Frodo", Class = RpgClass.Knight, Strength = 15, Intelligence = 12 },
            new Character { Id = 2, Name = "Gandalf", Class = RpgClass.Mage, Strength = 8, Intelligence = 18 },
            new Character { Id = 3, Name = "Aragorn", Class = RpgClass.Knight, Strength = 20, Intelligence = 10 },
            new Character { Id = 4, Name = "Legolas", Class = RpgClass.Knight, Strength = 17, Intelligence = 14 },
            new Character { Id = 5, Name = "Elrond", Class = RpgClass.Cleric, Strength = 12, Intelligence = 16 }
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter)
        {
            var serviceResponse =new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data=character;

            return serviceResponse;
        }
    }
}
