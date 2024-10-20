using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.MPE;
using UnityEngine;

// Script by Rad
public class Pokemon
{
    // Properties to access Pokemons info in other files.
    public PokemonBase BaseStats { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<Move> Moves { get; set; }
    
    // Construtor to create pokemon
    public Pokemon(PokemonBase pBase, int pLevel)
    {
        BaseStats = pBase;
        Level = pLevel;
        HP = BaseStats.MaxHp;

        Moves = new List<Move>();
        foreach (var move in BaseStats.LearnableMoves)
        {
            if (move.Level <= Level)
            {
                Moves.Add(new Move(move.Base));
            }
            if (Moves.Count >= 4)
            {
                break;
            }
        }
    }

    // Following functions are properties to return the stat of the pokemon corresponding to it's level.
    public int Attack 
    {
        get { return Mathf.FloorToInt((BaseStats.Attack * Level) / 100f) + 5; }
    }
    public int Defense 
    {
        get { return Mathf.FloorToInt((BaseStats.Defense * Level) / 100f) + 5; }
    }
    public int MaxHp 
    {
        get { return Mathf.FloorToInt((BaseStats.MaxHp * Level) / 100f) + 10; }
    }
    public int SpAttack 
    {
        get { return Mathf.FloorToInt((BaseStats.SpAttack * Level) / 100f) + 5; }
    }
    public int SpDefense 
    {
        get { return Mathf.FloorToInt((BaseStats.SpDefense * Level) / 100f) + 5; }
    }
    public int Speed 
    {
        get { return Mathf.FloorToInt((BaseStats.Speed * Level) / 100f) + 5; }
    }

    // Damage Function using formulas based off the real Pokemon game
    public bool TakeDamage(Move move, Pokemon attacker)
    {
        float randomMultiplier = Random.Range(0.85f, 1f);
        float levelMultiplier = (2 * attacker.Level + 10) / 250f;
        float damageCalculator = levelMultiplier * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(damageCalculator * randomMultiplier);

        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
            // Fainted
            return true;
        }
        // Did not faint
        return false;
    }
}
