using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class Pokemon
{

    // Independent stats of a Pokemon
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    public PokemonBase baseStats { 
        get { return _base; }
    }
    public int Level { 
        get { return level; }
    }
    public int HP { get; set; }
    public List<Move> Moves { get; set; }
    public int Exp { get; set; }

    // Is called to update the Pokemon's status after a move in the Battle
    public void Init()
    {
        // Determines the current moveset of that pokemon
        Moves = new List<Move>();
        // For each loop checks every value in the list and goes through them
        foreach (var move in baseStats.LearnableMoves)
        {
            // Adds the exp to the moveset if is sufficient level
            if (move.Level <= Level)
            {
                Moves.Add(new Move(move.Base));
            }
            // If moveset is filled does not add any moves
            if (Moves.Count >= 4)
            {
                break;
            }
        }
        // Updates HP
        HP = MaxHp;
        // Updates EXP
        Exp = baseStats.GetExpForLevel(Level);
    }

    // Used every time the Pokemon gets exp to check whether the EXP is more than the required exp to level
    public bool CheckForLevelUp()
    {
        // Checks if EXP gained is sufficient enough to pass through exp requirements
        if (Exp > baseStats.GetExpForLevel(level + 1))
        {
            // LEVELS UP WOW GOOD JOB
            ++level;
            return true;
        }
        // didnt level up so its false what a surprise
        return false;
    }

    // Following Reference Functions to be able to use in other scripts
    public int Attack 
    {
        get { return Mathf.FloorToInt((baseStats.Attack * Level) / 100f) + 5; }
    }
    public int Defense 
    {
        get { return Mathf.FloorToInt((baseStats.Defense * Level) / 100f) + 5; }
    }
    public int MaxHp 
    {
        get { return Mathf.FloorToInt((baseStats.MaxHp * Level) / 100f) + 10; }
    }
    public int SpAttack 
    {
        get { return Mathf.FloorToInt((baseStats.SpAttack * Level) / 100f) + 5; }
    }
    public int SpDefense 
    {
        get { return Mathf.FloorToInt((baseStats.SpDefense * Level) / 100f) + 5; }
    }
    public int Speed 
    {
        get { return Mathf.FloorToInt((baseStats.Speed * Level) / 100f) + 5; }
    }

    // Changes pokemon HP based off of given attack and move.
    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        // Random value to determine crit
        float critical = 1f;
        if (Random.value * 100f <= 6.25f)
            critical = 2f;
        // Determines the effectiveness of the move type towards the pokemon type
        float type = TypeChart.GetEffectiveness(move.baseStats.Type, this.baseStats.Type1) * TypeChart.GetEffectiveness(move.baseStats.Type, this.baseStats.Type2);
        // Gets variables of the move side effects
        var damageDetails = new DamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            Fainted = false
        };
        // Damage formula through official Pokemon
        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.baseStats.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);
        // Subtract current HP by damage
        HP -= damage;
        // Checks if below 0 and if so kills pokemon
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }
        
        return damageDetails;
    }

    // Random move for the enemy Pokemon to choose
    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}

// Damage Details that determine the results of a move, such as crits, fainted enemy, and type effectiveness
public class DamageDetails
{
    // Following variables determine the following variable names
    public bool Fainted { get; set; }

    public float Critical { get; set; }

    public float TypeEffectiveness { get; set; }    
}
