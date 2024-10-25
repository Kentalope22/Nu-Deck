using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    // Define movement variables
    public float moveSpeed = 5f;
    public float moveDist = 1f;

    // status of movement and position
    private bool moving = false;
    private Vector3 pos_;

    void StartBattle()
    {
        // FIXME this function doesn't work for whatever reason. Variable names are the primary culpret
        //state = GameState.Battle;
        //BattleSystem.gameObject.SetActive(true);
        //worldCamera.gameObject.SetActive(false);

        //var playerParty = playerController.GetComponent<PokemonParty>();
        //var wildPokemon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();

        //BattleSystem.StartBattle(playerParty, wildPokemon);
    }



    // Start is called before the first frame update
    void Start()
    {

        pos_ = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // base case if sprite is already moving
        if (moving) { return; }

        Vector3 dir = Vector3.zero;

        // binding keys to move sprite
        if (Input.GetKey(KeyCode.W))
        {

            dir = new Vector3(0f, moveDist, 0f);

        }
        else if (Input.GetKey(KeyCode.S))
        {

            dir = new Vector3(0f, -moveDist, 0f);

        }
        else if (Input.GetKey(KeyCode.A))
        {

            dir = new Vector3(-moveDist, 0f, 0f);

        }
        else if (Input.GetKey(KeyCode.D))
        {

            dir = new Vector3(moveDist, 0f, 0f);
        }
        if (dir != Vector3.zero)
        {
            pos_ = transform.position + dir;
            StartCoroutine(MoveToTile());
        }


    }

    private System.Collections.IEnumerator MoveToTile()
    {

        moving = true;

        while (Vector3.Distance(transform.position, pos_) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos_, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = pos_;
        moving = false;
    }
}
