using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.MPE;
using UnityEngine;

[System.Serializable]
public class Pokemon
{
    [SerializeField] PokemonBase _base; // rename?
    [SerializeField] int level;
    public PokemonBase baseStats {
        get {
            return _base;
        }
    }
    public int Level { 
        get {
            return level;
        }
    }
    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public void Init()
    {
       
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
