using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle }


public class GameController : MonoBehaviour
{
    //video #12
    [SerializeField] PlayerMove playerMove;
    [SerializeField] BattleSystem battleSystem;

    GameState state;

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerMove.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}
