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
        if (collision.transform.CompareTag("Player"))
        {
            LevelManager.Instance.Retry();
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

        if (collision.gameObject.name.Equals("RightArm")|| collision.gameObject.name.Equals("LeftArm"))
        {
            return;
        }

        Destroy(this.gameObject);
    }
}
