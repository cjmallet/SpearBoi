using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLever : MonoBehaviour
{
    [SerializeField]
    private GameObject nickolasCage;

    [SerializeField]
    private GameObject bomb;

    private bool playerInRange;
    private bool destroyed;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) &&!destroyed)
        {
            Destroy(nickolasCage);
            bomb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.001f);
            destroyed = true;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
