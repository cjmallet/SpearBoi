using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saw : MonoBehaviour
{
    [SerializeField] private float moveSpeedBoss;
    [SerializeField] private int moveSpeed;
    [HideInInspector] public ShootDirection shootDirection;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (shootDirection)
        {
            case ShootDirection.UP:
                transform.position = new Vector2(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime));
                break;
            case ShootDirection.RIGHT:
                transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
                break;
            case ShootDirection.DOWN:
                transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed * Time.deltaTime));
                break;
            case ShootDirection.LEFT:
                transform.position = new Vector2(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y);
                break;
            case ShootDirection.BOSSSPRAY:
                transform.position += -transform.up * moveSpeed * Time.deltaTime;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.transform.CompareTag("Coin"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Spear"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("AddSpear"))
        {
            return;
        }

        Destroy(this.gameObject);
    }

    public enum ShootDirection
    {
        UP,
        RIGHT,
        DOWN,
        LEFT,
        BOSSSPRAY
    }
}
