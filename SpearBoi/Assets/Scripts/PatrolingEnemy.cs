using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolingEnemy : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private playerControler playercontroller;

    private Transform patrolPoint1, patrolPoint2;
    private float timer;
    public int state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state==1)
        {
            transform.position = new Vector2(transform.position.x-(movementSpeed*Time.deltaTime), transform.position.y);
        }

        if (state==2)
        {
            transform.position = new Vector2(transform.position.x + (movementSpeed * Time.deltaTime), transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PatrolPoint") && (state == 1 && collision.name.Contains("Left") || state == 2 && collision.name.Contains("Right")))
        {
            if (state == 1)
            {
                state = 2;
            }
            else if (state== 2)
            {
                state = 1;
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
            playercontroller.currentHealth--;
        }
    }

    public void Die()
    {
        Debug.Log("enemy die");
        Destroy(gameObject);
    }
}