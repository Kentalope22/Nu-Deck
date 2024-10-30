using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    public event Action<bool> OnBattleOver;

    BattleState state;
    int currentAction;
    int currentMove;

    public void StartBattle()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        dialogBox.SetMoveNames(playerUnit.Pokemon.Moves);

       yield return dialogBox.TypeDialog($"A wild {enemyUnit.Pokemon.baseStats.Name} appeared.");

       PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true); //dialog box shows the fight and run option on the right //
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true); // dialog box shows the moves //
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;

        var move = playerUnit.Pokemon.Moves[currentMove]; // player makes a move //
        yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.baseStats.Name} used {move.baseStats.Name}!"); // dialog box shows what move the player choose //


        var damageDetails = enemyUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon); //  enemy takes damage //
        yield return enemyHud.UpdateHP(); // updates enemy HP //
        yield return ShowDamageDetails(damageDetails); 

        if (damageDetails.Fainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.baseStats.Name} Fainted!"); // dialog box shows enemy fainted //
            OnBattleOver(true); // battle is over and goes back to the world //
        }
        else
        {
            StartCoroutine(EnemyMove()); // if the enemy is not dead, it's the enemy turn to make a move //
        }
    }

    IEnumerator EnemyMove() // vice versa from the player move //
    {
        state = BattleState.EnemyMove;

        var move = enemyUnit.Pokemon.GetRandomMove();
        yield return dialogBox.TypeDialog($"{enemyUnit.Pokemon.baseStats.Name} used {move.baseStats.Name}!"); 

        var damageDetails = playerUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return playerHud.UpdateHP();
        yield return ShowDamageDetails(damageDetails);

        if (damageDetails.Fainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.Pokemon.baseStats.Name} Fainted!");
            OnBattleOver(false);
        }
        else
        {
            PlayerAction();
        }
    }

    IEnumerator ShowDamageDetails(DamageDetails damageDetails) //shows the damage details based on the attack //
    {
        if (damageDetails.Critical > 1f)
            yield return dialogBox.TypeDialog("A critical hit!");

        if (damageDetails.TypeEffectiveness > 1f)
            yield return dialogBox.TypeDialog("It's super effective!");
        else if (damageDetails.TypeEffectiveness < 1f)
            yield return dialogBox.TypeDialog("It's not very effective!");
    }

    public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction) // player is choosing an action like fight or run //
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove) // player has chosen to fight and is now selecting a specfic move to use //
        {
            HandleMoveSelection();
        }
    }

    void HandleActionSelection() // inputing arrow keys for action selection//
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z)) // Z for selecting an action //
        {
            if (currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Run
            }
        }
    }
    
    void HandleMoveSelection() // inputing arrow keys for move selection//
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 1)
                ++currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Pokemon.Moves.Count - 2)
                currentMove += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
                currentMove -= 2;
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Pokemon.Moves [currentMove]);

        if (Input.GetKeyDown(KeyCode.Z)) // Z for selecting an action //
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
