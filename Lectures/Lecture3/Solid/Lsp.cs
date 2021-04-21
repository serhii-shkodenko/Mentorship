using System;
using System.Collections.Generic;

namespace Lecture3.Solid
{
    public class Lsp
    {
        public void PrintEmenies()
        {
            var pokemons = new List<Pokemon>
            {
                new Aron(),
                new Bulbasaur(),
            };

            SetEmenies(pokemons, new Pokemon());

            foreach(var pokemon in pokemons)
            {
                Console.WriteLine(pokemon.Enemy);
            }
        }

        public void SetEmenies(IEnumerable<Pokemon> pokemons, Pokemon enemy)
        {
            foreach (var pokemon in pokemons)
            {
                pokemon.AssignEnemy(enemy);
            }
        }

        public class Pokemon
        {
            public string Name { get; set; }

            public int Attack { get; set; }

            public Pokemon Enemy { get; protected set; }

            public virtual void AssignEnemy(Pokemon pokemon)
            {
                Enemy = pokemon;
            }
        }

        public class Bulbasaur : Pokemon
        {
            public override void AssignEnemy(Pokemon pokemon)
            {
                throw new ArgumentException("Bulbasaur has no emenies!", nameof(pokemon));
            }
        }

        public class Aron : Pokemon
        {
            public override void AssignEnemy(Pokemon pokemon)
            {
                Enemy = pokemon;
            }
        }
    }
}