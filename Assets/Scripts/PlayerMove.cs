using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{

    // Define movement variables
    public float moveSpeed = 5f;
    public float moveDist = 1f;

    public LayerMask solidObjectsLayer;
    //Grass pokemon encounter layer
    public LayerMask grassLayer;

    public event Action OnEcountered;

    // status of movement and position
    // boolean is used to make sure only one action is done at a time
    private bool moving = false;
    private Vector3 pos_;
    //Walking animation code
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

        pos_ = transform.position;
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        // base case if sprite is already moving
        // prevents user from doing multiple inputs at once when sprite is moving
        if (moving) { return; }

        // defining dir variable to be at 0,0,0 serves as default value
        Vector3 dir = Vector3.zero;

        // binding keys to move sprite

        // taking in arrowkeys and using their keycodes to move sprite
        if (Input.GetKey(KeyCode.UpArrow))
        {

            // update dir variable to a new vector object in +y direction
            dir = new Vector3(0f, moveDist, 0f);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {

            // update dir variable to a new vector object in -y direction
            dir = new Vector3(0f, -moveDist, 0f);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            // update dir variable to a new vector object in -x direction
            dir = new Vector3(-moveDist, 0f, 0f);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            // update dir variable to a new vector object in +x direction
            dir = new Vector3(moveDist, 0f, 0f);
            
        }

        // condition that dir is no longer zero (sprite moved)
        if (dir != Vector3.zero)
        {
        
            animator.SetFloat("MoveX", dir.x);
            animator.SetFloat("MoveY", dir.y);
            
            // create new target position and set to current position + change of position (dir)
            Vector3 targetPosition = transform.position + dir;

            // condition to check if the sprite can walk to new targetposition
            if (isWalkable(targetPosition))
            {
                // update sprite's postion to the target postion 
                pos_ = targetPosition;

                /* 
                movement operation will execute over multiple frames using coroutine
                this makes the movement more smooth instead of an instant jump to positions
                */
                StartCoroutine(MoveToTile());
            }
        }

        animator.SetBool("isMoving", moving);

    }

    // Ienumerator method allows use of coroutine keyword
    private System.Collections.IEnumerator MoveToTile()
    {

        // update moving bool when key is pressed
        moving = true;

        // loop to make sure sprite's current position is moving to the new position till distance is < 0.01
        while (Vector3.Distance(transform.position, pos_) > 0.01f)
        {
            // move sprite a small distance each frame till position is met
            // movespeed and time are the max dist. sprite can move in each frame (based on framerate)
            transform.position = Vector3.MoveTowards(transform.position, pos_, moveSpeed * Time.deltaTime);

            // pauses coroutine till next frame
            yield return null;
        }

        // set the current position of sprite to the updated postion pos_
        transform.position = pos_;
        // update moving as stopped
        moving = false;
        
        //Executes code to check for pokemon and start a battle scene
        CheckForEncounters();
    }
    private bool isWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.3f, solidObjectsLayer) != null) {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.3f, grassLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= 10)
            {
                animator.SetBool("isMoving", false);
                OnEcountered();
            }
        }
    }
}
