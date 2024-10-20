using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by Rad
// Makes so Move Object can be created through Unity Hub
[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new Move")]
public class MoveBase : ScriptableObject
{
    // Variables of the Object that can be set through Unity Hub.
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Pokemontype type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    // Properties that allow other files to access these member variables
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
