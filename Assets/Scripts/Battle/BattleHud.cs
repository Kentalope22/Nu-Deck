using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] GameObject expBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.baseStats.Name;
        SetLevel();
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);
        SetExp();
    }

    public void SetLevel()
    {
        levelText.text = "Lvl " + _pokemon.Level;
    }

    public void SetExp()
    {
        if (expBar == null) return;

        float normalizedExp = GetNormalizedExp();
        expBar.transform.localScale = new Vector3(normalizedExp, 1, 1);
 
    }
    public IEnumerator SetExpSmooth(bool reset=false)
    {
        if (expBar == null) yield break;
        if (reset) expBar.transform.localScale = new Vector3(0, 1, 1);

        float normalizedExp = GetNormalizedExp();
        expBar.transform.DOScaleX(normalizedExp, 1.5f).WaitForCompletion();
    }
    float GetNormalizedExp()
    {
        int currLevelExp = _pokemon.baseStats.GetExpForLevel(_pokemon.Level);
        int nextLevelExp = _pokemon.baseStats.GetExpForLevel(_pokemon.Level + 1);

        float normalizedExp = (float)(_pokemon.Exp - currLevelExp) / (nextLevelExp - currLevelExp); 
        return Mathf.Clamp01(normalizedExp);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_pokemon.HP / _pokemon.MaxHp); 
    }
}
