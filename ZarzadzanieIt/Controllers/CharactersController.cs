using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarzadzanieIt.Models;
using ZarzadzanieIt.WebModels;

namespace ZarzadzanieIt.Controllers
{
    [ApiController]
    public class CharactersController : ControllerBase
    {
        public const string Route = "api/characters/";
        private static DataContext _dataContext;

        public CharactersController()
        {
            if (_dataContext == null)
            {
                _dataContext = new DataContext();
            }
        }

        [HttpGet(Route)]
        public ActionResult<List<Character>> GetAll()
        {
            var characters = _dataContext.Characters;

            return new OkObjectResult(characters);
        }

        [HttpGet(Route + "{id}")]
        public ActionResult<Character> GetById([FromRoute] int id)
        {
            var character = _dataContext.Characters
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (character == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(character);
        }

        [HttpPost(Route)]
        public ActionResult<Character> CreateCharacter([FromBody] CharacterWebModel characterWebModel)
        {
            if (string.IsNullOrEmpty(characterWebModel.Name))
            {
                return new BadRequestResult();
            }

            var id = _dataContext.Characters.Last().Id;

            var id2 = _dataContext.Characters
                .Select(x => x.Id)
                .Max();

            var character = new Character
            {
                Id = id + 1,
                Name = characterWebModel.Name,
                Age = characterWebModel.Age,
                Level = characterWebModel.Level
            };

            _dataContext.Characters.Add(character);

            return new OkObjectResult(character);
        }

        private bool IsIdEqual(Character c, int id)
        {
            return c.Id == id;
        }
    }
}
