using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows for easier Pokemon creation
[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    // Variables present in those type of Pokemons
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

    [SerializeField] int expYield;
    [SerializeField] GrowthRate growthRate;

    [SerializeField] List<LearnableMove> learnableMoves;

    // Calculates the given EXP needed for each level

    public int GetExpForLevel(int level)
    {
        // Uses growth rate to determine whether its less or more exp
        if(growthRate == GrowthRate.Fast)
        {
            return 4 * level * level * level / 5;
        }
        else if(growthRate == GrowthRate.MediumFast)
        {
            return level * level * level;
        }
        // If growth rate isn't applicable then pokemon EXP is wrong
        return -1;
    }
    // Reference Functions to access these variables in other scripts
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
    public int ExpYield => expYield;

    public GrowthRate GrowthRate => growthRate;
}

[System.Serializable]
// Class dealing with whether a move is learnable by the pokemon
public class LearnableMove
{
    // Levels and moveBase for the Pokemons base
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

// Uses enum to create a list with the Pokemon types
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

// List for type of pokemon growth rates
public enum GrowthRate
{
    Fast, MediumFast
}

// Class the calculates the damage effectiveness of the types to one another
public class TypeChart
{
    // 2D array for all the type effectiveness to each type
    static float[][] chart =
    {
        // The NUMBESR MEAN THE MULTIPLIER FOR THE EACH TYPE
        //                       Nor   Fir   Wat   Ele   Gra   Ice   Fig   Poi   Gro   Fly   Psy   Bug   Roc   Gho   Dra         Fai
        /*Normal*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 0,    1f,      1f},
        /*Fire*/    new float[] {1f,   0.5f, 0.5f, 1f,   2f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f,       1f},
        /*Water*/   new float[] {1f,   2f,   0.5f, 1f,   0.5f, 1f,   1f,   1f,   2f,   1f,   1f,   1f,   2f,   1f,   0.5f,      1f},
        /*Electric*/new float[] {1f,   1f,   2f,   0.5f, 0.5f, 1f,   1f,   1f,   0f,   2f,   1f,   1f,   1f,   1f,   0.5f,      1f},
        /*Grass*/   new float[] {1f,   0.5f, 2f,   1f,   0.5f, 1f,   1f,   0.5f, 2f,   0.5f, 1f,   0.5f, 2f,   1f,   0.5f,     1f},
        /*Ice*/     new float[] {1f,   0.5f, 0.5f, 1f,   2f,   0.5f, 1f,   1f,   2f,   2f,   1f,   1f,   1f,   1f,   2f,       1f},
        /*Fighting*/new float[] {2f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f,   0.5f, 0.5f, 0.5f, 2f,   0f,   1f,        0.5f},
        /*Poison*/  new float[] {1f,   1f,   1f,   1f,   2f,   1f,   1f,   0.5f, 0.5f, 1f,   1f,   1f,   0.5f, 0.5f, 1f,        2f},
        /*Ground*/  new float[] {1f,   2f,   1f,   2f,   0.5f, 1f,   1f,   2f,   1f,   0f,   1f,   0.5f, 2f,   1f,   1f,         1f},
        /*Flying*/  new float[] {1f,   1f,   1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,       1f},
        /*Psychic*/ new float[] {1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   1f,   1f,   0.5f, 1f,   1f,   1f,   1f,       1f},
        /*Bug*/     new float[] {1f,   0.5f, 1f,   1f,   2f,   1f,   0.5f, 0.5f, 1f,   0.5f, 2f,   1f,   1f,   0.5f, 1f,       0.5f},
        /*Rock*/    new float[] {1f,   2f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,       1f},
        /*Ghost*/   new float[] {0f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   2f,   1f,      1f},
        /*Dragon*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   2f,      0f},
        /*Fairy*/   new float[] {1f,   0.5f, 1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   1f,   1f,   1f,   2f,      1f},
    };

    // Gets effectiveness of move based off the Pokemons base stats
    public static float GetEffectiveness(Pokemontype attackType, Pokemontype defenseType)
    {
        // If it ever comes the case that a pokemon has no type it will have no effect
        if (attackType == Pokemontype.None || defenseType == Pokemontype.None)
            return 1;
        
        // Finds the respective type in the 2 ad array of type effectiveness
        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;
        // Finds the multiplier of those two types
        return chart[row][col];
    }
}