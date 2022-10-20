using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxPit : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemySpawnpoint;
    public Transform enemySpawnpoint2;
    public bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == false)
        {
            isTriggered = true;
            Instantiate(enemy, enemySpawnpoint.position, Quaternion.identity);
            Instantiate(enemy, enemySpawnpoint2.position, Quaternion.identity);
        }
    }
}
