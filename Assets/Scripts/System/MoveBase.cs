using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows for creation in the Unity Hub
[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new Move")]
public class MoveBase : ScriptableObject
{
    // Move stats found in every one on these kind of moves
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Pokemontype type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    // Reference Functions to allows these variable to be used in other scripts
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Pokemontype Type 
    {
        get { return type; }
    }

    public int Power
    {
        get { return power; }
    }
    public int PP
    {
        get { return pp; }
    }
    public int Accuracy
    {
        get { return accuracy; }
    }
}