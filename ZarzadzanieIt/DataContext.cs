using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarzadzanieIt.Models;

namespace ZarzadzanieIt
{
    public class DataContext
    {
        public List<Character> Characters { get; set; }

        public DataContext()
        {
            Characters = new List<Character>
            {
                new Character
                {
                    Id = 1,
                    Name = "Ylvonn",
                    Level = 3,
                    Age = 26,

                },
                new Character
                {
                    Id = 2,
                    Name = "Sybil",
                    Level = 2,
                    Age = 21,

                },
                new Character
                {
                    Id = 3,
                    Name = "Rehael",
                    Level = 5,
                    Age = 41,

                },
                new Character
                {
                    Id = 4,
                    Name = "Shempor",
                    Level = 4,
                    Age = 36,
                }
            };
        }
    }
}
