using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxPit : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public Transform enemySpawnpoint;
    public Transform enemySpawnpoint2;
    public Transform enemySpawnpoint3;
    public Transform enemySpawnpoint4;
    public GameObject magnetDoor;
    public float waitTime;
    public float timeBetweenWaves;
    public bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == false)
        {
            isTriggered = true;
            enemy1.transform.position = enemySpawnpoint.position;
            enemy2.transform.position = enemySpawnpoint2.position;
            enemy3.transform.position = enemySpawnpoint3.position;
            enemy4.transform.position = enemySpawnpoint4.position;

            StartCoroutine(DestroyDoor(200));

            StartCoroutine(SpawnEnemies(1));

        }
    }

    IEnumerator DestroyDoor(float WaitTime)
    {
        
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("timer done");
        enemy1.transform.position = enemySpawnpoint.position;
        enemy2.transform.position = enemySpawnpoint2.position;
        Destroy(magnetDoor);
    }

    IEnumerator SpawnEnemies(float WaitTime)
    {

        yield return new WaitForSeconds(WaitTime);

        enemy1.transform.position = enemySpawnpoint.position;
        enemy2.transform.position = enemySpawnpoint2.position;
        Destroy(magnetDoor);
    }
}
