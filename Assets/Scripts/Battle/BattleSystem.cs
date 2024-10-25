using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code: Parker Oria
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;

    PokemonParty playerParty;
    Pokemon wildPokemon;

    public void StartBattle(PokemonParty playerParty, Pokemon wildPokemon)
    {
        this.playerParty = playerParty;
        this.wildPokemon = wildPokemon;
        StartCoroutine(SetupBattle());
    }

    private void Start()
    {
        SetupBattle();
    }

    void PlayerAction()
    {
        // FIXME not sure why this isnt working, variable names?
        //state = BattleUnit PlayerAction;
    }


    public IEnumerator SetupBattle()
    {
        playerUnit.Setup(playerParty.GetHealthyPokemon());
        enemyUnit.Setup(wildPokemon);
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        
        // Honestly I dont know whats going on here. Someone smarter help me out
        //dialogBox.SetMoveNames(playerUnit.Pokemon.Moves);

        //yield return dialogBox.TypeDialog($"A wil");
        PlayerAction();
        return null;
    }
}

