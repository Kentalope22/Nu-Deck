using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] bool isPlayerUnit;
    [SerializeField] BattleHud hud;
 

    public Pokemon Pokemon { get; set; }

    public bool IsPlayerUnit
    {
        get { return isPlayerUnit;  }
    }

    public BattleHud Hud
    {
        get { return hud; }
    }

    public void Setup (Pokemon pokemon) 
    {
        Pokemon = pokemon;
        if (isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.baseStats.BackSprite;
        else
            GetComponent<Image>().sprite = Pokemon.baseStats.FrontSprite;
    }
}
