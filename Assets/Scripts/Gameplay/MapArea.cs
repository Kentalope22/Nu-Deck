using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code: Parker Oria
public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pokemon> wildPokemon;
    // Assign script to grid
    public Pokemon GetRandomWildPokemon()
    {
        return wildPokemon[Random.Range(0, wildPokemon.Count)];
    }
}
