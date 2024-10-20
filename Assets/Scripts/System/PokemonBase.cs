using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by Rad
// Asset so this object can be created in the Unity Hub
[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    // Properties of the Object that can be edited in Unity Hub
    [SerializeField] new string name;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] Pokemontype type1;
    [SerializeField] Pokemontype type2;

    // Base Stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    [SerializeField] List<LearnableMove> learnableMoves;

    // Properties to be able to return these variables in other files
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }


    public Pokemontype Type1
    {
        get { return type1; }
    }
    public Pokemontype Type2
    {
        get { return type2; }
    }
    public int Attack
    {
        get { return attack; }
    }
    public int Defense
    {
        get { return defense; }
    }
    public int MaxHp
    {
        get { return maxHp; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int SpAttack
    {
        get { return spAttack; }
    }
    public int SpDefense
    {
        get { return spDefense; }
    }
    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }
    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]
// Creates the future or current learnable moves of the pokemon based on level
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

// Typing of the pokemons that will be dealt with for the battle system
public enum Pokemontype
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Fairy
}