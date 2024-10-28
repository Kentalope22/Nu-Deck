using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemons;


    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.Init();
        }
    }
    public Pokemon GetHealthyPokemon()
    {
        // Gets the first alive pokemon in the Party
        return pokemons.Where(x => x.HP > 0).FirstOrDefault();
        //for (var i = 0; i < pokemons.Count; i++)
        //{
        //    if (pokemons[i].HP > 0)
        //    {
        //        return pokemons[i];
        //    }
        //}
        //return null;
    }


}
