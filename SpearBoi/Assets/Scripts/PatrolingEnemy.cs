using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolingEnemy : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private MoveState moveState;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private bool immortal;

    // Update is called once per frame
    void Update()
    {
        if (moveState == MoveState.LEFT)
        {
            transform.position = new Vector2(transform.position.x-(movementSpeed*Time.deltaTime), transform.position.y);
        }

        if (moveState == MoveState.RIGHT)
        {
            transform.position = new Vector2(transform.position.x + (movementSpeed * Time.deltaTime), transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PatrolPoint") && (moveState == MoveState.LEFT && collision.name.Contains("Left") || moveState == MoveState.RIGHT && collision.name.Contains("Right")))
        {
            if (moveState == MoveState.LEFT)
            {
                moveState = MoveState.RIGHT;
            }
            else if (moveState == MoveState.RIGHT)
            {
                moveState = MoveState.LEFT;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            if (collision.transform.GetComponent<Spear>().hasHit)
            {
                Physics2D.IgnoreCollision(collision.collider,GetComponent<BoxCollider2D>());
            }
        }

        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Die()
    {
        if (!immortal)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private enum MoveState
    {
        LEFT,
        RIGHT
    }
}