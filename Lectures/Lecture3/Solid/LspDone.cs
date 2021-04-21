using System;
using System.Collections.Generic;

namespace Lecture3.Solid
{
    public class LspDone
    {
        public void PrintEmenies()
        {
            var pokemons = new List<PokemonWithEnemy>
            {
                new Aron(),
            };

            SetEmenies(pokemons, new BasePokemon());
        }

        public void SetEmenies(IEnumerable<PokemonWithEnemy> pokemons, BasePokemon enemy)
        {
            foreach (var pokemon in pokemons)
            {
                pokemon.AssignEnemy(enemy);
            }
        }

        public class BasePokemon
        {
            public string Name { get; set; }

            public int Attack { get; set; }
        }

        public class PokemonWithEnemy : BasePokemon
        {
            public BasePokemon Enemy { get; set; }

            public virtual void AssignEnemy(BasePokemon pokemon)
            {
                Enemy = pokemon;
                Console.WriteLine($"{nameof(PokemonWithEnemy)} has enemy: {Enemy}");
            }
        }

        public interface ISuperPredator
        {
        }

        public class Bulbasaur : BasePokemon, ISuperPredator
        {
        }

        public class Aron : PokemonWithEnemy
        {
        }
    }
}