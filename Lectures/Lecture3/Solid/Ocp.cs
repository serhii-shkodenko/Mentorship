using System;

namespace Lecture3.Solid
{
    public enum PokemonType
    {
        None,
        Bulbasaur,
        Metapod,
        Lillipup,
        Lopunny,
    }

    public static class PokemonExtensions
    {
        public static Pokemon DoSomeAction(this Pokemon pokemon)
        {
            pokemon.Name = "dsfsdf";
            return pokemon;
        }
    }

    public class Pokemon
    {
        public string Name { get; set; }

        public Pokemon(PokemonType type)
        {
            Type = type;
        }

        public PokemonType Type { get; private set; }

        public void Attack()
        {
        }
    }

    public class Ocp
    {
        public void PrintPokemonMessage(Pokemon pokemon)
        {
            if (pokemon.Type == PokemonType.Bulbasaur)
            {
                Console.Write($"{pokemon.Type} wants to eat.");
            }

            if (pokemon.Type == PokemonType.Lillipup)
            {
                Console.Write($"{pokemon.Type} wants to walk.");
            }

            if (pokemon.Type == PokemonType.Lillipup)
            {
                Console.Write($"{pokemon.Type} wants to slip.");
            }

            if (pokemon.Type == PokemonType.Lopunny)
            {
                Console.Write($"{pokemon.Type} wants to swim.");
            }
        }

        public void PrintPokemonMessageAdvanced(PokemonAdvanced pokemon)
        {
            pokemon.PrintMessage();
        }
    }

    public abstract class PokemonAdvanced
    {
        public abstract void PrintMessage();
    }

    public abstract class Bulbasaur : PokemonAdvanced
    {
        public override void PrintMessage()
        {
            Console.Write($"{nameof(Bulbasaur)} wants to eat.");
        }
    }
}