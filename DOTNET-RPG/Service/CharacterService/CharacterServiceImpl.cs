
using DOTNET_RPG.Data;
using DOTNET_RPG.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_RPG.Service.CharacterService
{
    public class CharacterServiceImpl : ICharacterService
    {
        private readonly DataContext _dataContext;

        public CharacterServiceImpl(DataContext context)
        {
            _dataContext = context;
        }
        //private static List<Character> characters = new List<Character>()
        //{
        //    new Character(),
        //    new Character { Id = 1, Name = "Frodo", Class = RpgClass.Knight, Strength = 15, Intelligence = 12 },
        //    new Character { Id = 2, Name = "Gandalf", Class = RpgClass.Mage, Strength = 8, Intelligence = 18 },
        //    new Character { Id = 3, Name = "Aragorn", Class = RpgClass.Knight, Strength = 20, Intelligence = 10 },
        //    new Character { Id = 4, Name = "Legolas", Class = RpgClass.Knight, Strength = 17, Intelligence = 14 },
        //    new Character { Id = 5, Name = "Elrond", Class = RpgClass.Cleric, Strength = 12, Intelligence = 16 }
        //};

        public async Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter)
        {
            var serviceResponse =new ServiceResponse<List<Character>>();
            _dataContext.Characters.Add(newCharacter);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data= await _dataContext.Characters.ToListAsync(); ;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();
            serviceResponse.Data=dbCharacters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();

            serviceResponse.Data=dbCharacters.FirstOrDefault(c=>c.Id==id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> UpdateCharacter(Character updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<Character>();

            try
            {
                var character = await _dataContext.Characters.FirstOrDefaultAsync(c=>c.Id==updatedCharacter.Id);
                if (character is null)
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = character;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();

            try
            {
                var character = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
                if (character is null)
                    throw new Exception($"Character with Id '{id}' not found.");

                _dataContext.Characters.Remove(character);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data =
                    await _dataContext.Characters.ToListAsync();
                        
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
