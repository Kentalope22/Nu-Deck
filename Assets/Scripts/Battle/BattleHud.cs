using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.baseStats.Name; // shows the pokemon's name//
        levelText.text = "Lvl " + pokemon.Level; // shows the level of pokemon //
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp); // HP Bar
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_pokemon.HP / _pokemon.MaxHp); // HP bar decreases after either side takes damage //
    }
}
