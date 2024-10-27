using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    // Define movement variables
    public float moveSpeed = 5f;
    public float moveDist = 1f;

    public LayerMask solidObjectsLayer;
    //Grass pokemon encounter layer
    public LayerMask grassLayer;

    // status of movement and position
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
            animator.SetFloat("MoveX", dir.x);
            animator.SetFloat("MoveY", dir.y);

            Vector3 targetPosition = transform.position + dir;
            if (isWalkable(targetPosition))
            {
                pos_ = targetPosition;
                StartCoroutine(MoveToTile());
            }
        }

        animator.SetBool("isMoving", moving);

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
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encountered a wild pokemon");
            }
        }
    }
}