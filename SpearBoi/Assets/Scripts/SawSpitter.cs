using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpitter : MonoBehaviour
{
    public float shootTimer;
    [SerializeField] private Saw.ShootDirection shootDirection;
    [SerializeField] private GameObject saw;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            GameObject spawnedSaw = Instantiate(saw, transform.position, transform.parent.rotation);
            spawnedSaw.GetComponent<Saw>().shootDirection = shootDirection;
            timer = 0;
        }
    }
}
