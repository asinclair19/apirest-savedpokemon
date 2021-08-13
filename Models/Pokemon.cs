using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest_pokemon.Models
{
    public class Pokemon
    {
        public int Idsaved { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_experience { get; set; }
        public int Height { get; set; }
        public string Img { get; set; }
        public string Abilities { get; set; }
        public string Moves { get; set; }
        public string Stats { get; set; }
    }
}
