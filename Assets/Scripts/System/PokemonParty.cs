using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemons;


    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
    }


    private void Start()
    {   // initializes each pokemon in the party as a seperate pokemon
        foreach (var pokemon in pokemons)
        {
            pokemon.Init();
        }
    }

    public Pokemon GetHealthyPokemon() //Gets first pokemon that isn't fainted
    {
        return pokemons.Where(x => x.HP > 0).FirstOrDefault();
    }


}
