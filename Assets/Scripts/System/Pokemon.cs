using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.MPE;
using UnityEngine;

public class Pokemon
{
    PokemonBase baseStats;
    int level;
    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        baseStats = pBase;
        level = pLevel;
        HP = baseStats.MaxHp;

        Moves = new List<Move>();
        foreach (var move in baseStats.LearnableMoves)
        {
            if (move.Level <= level)
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
        get { return Mathf.FloorToInt((baseStats.Attack * level) / 100f) + 5; }
    }
    public int Defense 
    {
        get { return Mathf.FloorToInt((baseStats.Defense * level) / 100f) + 5; }
    }
    public int MaxHp 
    {
        get { return Mathf.FloorToInt((baseStats.MaxHp * level) / 100f) + 10; }
    }
    public int SpAttack 
    {
        get { return Mathf.FloorToInt((baseStats.SpAttack * level) / 100f) + 5; }
    }
    public int SpDefense 
    {
        get { return Mathf.FloorToInt((baseStats.SpDefense * level) / 100f) + 5; }
    }
    public int Speed 
    {
        get { return Mathf.FloorToInt((baseStats.Speed * level) / 100f) + 5; }
    }
}
