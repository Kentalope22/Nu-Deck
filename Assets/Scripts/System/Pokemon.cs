using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class Pokemon
{

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
    public void Init()
    {

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
        HP = MaxHp;
        Exp = baseStats.GetExpForLevel(Level);
    }

    public bool CheckForLevelUp()
    {
        if (Exp > baseStats.GetExpForLevel(level + 1))
        {
            ++level;
            return true;
        }
        return false;
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

    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float critical = 1f;
        if (Random.value * 100f <= 6.25f)
            critical = 2f;

        float type = TypeChart.GetEffectiveness(move.baseStats.Type, this.baseStats.Type1) * TypeChart.GetEffectiveness(move.baseStats.Type, this.baseStats.Type2);

        var damageDetails = new DamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            Fainted = false
        };

        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.baseStats.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }
        
        return damageDetails;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}

public class DamageDetails
{
    public bool Fainted { get; set; }

    public float Critical { get; set; }

    public float TypeEffectiveness { get; set; }    
}
