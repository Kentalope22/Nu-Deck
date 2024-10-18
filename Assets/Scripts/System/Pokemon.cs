using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.MPE;
using UnityEngine;

public class Pokemon
{
    public PokemonBase baseStats { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        baseStats = pBase;
        Level = pLevel;
        HP = MaxHp;

        Moves = new List<Move>();
        foreach (var move in baseStats.LearnableMoves)
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
}
