using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Wild Pokemon Encounters in the area
public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pokemon> wildPokemons;
    
    public Pokemon GetRandomWildPokemon()
    {
        var wildPokemon = wildPokemons[Random.Range(0, wildPokemons.Count)];
        wildPokemon.Init();
        return wildPokemon;
        // wildPokemon is the ending list of Pokemon
    }

}
