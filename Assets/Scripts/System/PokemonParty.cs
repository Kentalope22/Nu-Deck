using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{
    List<Pokemon> pokemonList;
    // Code: Parker Oria
    // Attach to Playergame object
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Pokemon GetHealthyPokemon()
    {
        // Gets the first pokemon in the party that is not fainted
        for (int i = 0; i < pokemonList.Count; i++)
        {
            if (pokemonList[i].HP > 0)
            {
                return pokemonList[i];
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
