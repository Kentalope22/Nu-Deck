using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Pokemontype type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

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