using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSaw : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private Vector3 playerPosition;

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;

        transform.position= Vector3.MoveTowards(transform.position, playerPosition, movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.Retry();
        }

        if (collision.gameObject.CompareTag("Spear"))
        {
            return;
        }

        Destroy(this.gameObject);
    }
}
