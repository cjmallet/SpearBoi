using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpitter : MonoBehaviour
{
    public float shootTimer;
    [SerializeField] private Saw.ShootDirection shootDirection;
    public GameObject saw;

    private float timer;

    [HideInInspector]
    public bool shotgunMode;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            if (!shotgunMode) 
            {
                GameObject spawnedSaw = Instantiate(saw, transform.position, transform.parent.rotation);
                if (spawnedSaw.GetComponent<Saw>() != null)
                {
                    spawnedSaw.GetComponent<Saw>().shootDirection = shootDirection;
                }
            }

            if (shotgunMode)
            {
                GameObject spawnedSaw1 = Instantiate(saw, transform.position, transform.parent.rotation);
                Quaternion shootdirection2 = new Quaternion(transform.parent.rotation.x, transform.parent.rotation.y, transform.parent.rotation.z+0.1f, transform.parent.rotation.w);
                GameObject spawnedSaw2 = Instantiate(saw, transform.position, shootdirection2);
                Quaternion shootdirection3 = new Quaternion(transform.parent.rotation.x, transform.parent.rotation.y, transform.parent.rotation.z-0.1f, transform.parent.rotation.w);
                GameObject spawnedSaw3 = Instantiate(saw, transform.position, shootdirection3);
                spawnedSaw1.GetComponent<Saw>().shootDirection = shootDirection;
                spawnedSaw2.GetComponent<Saw>().shootDirection = shootDirection;
                spawnedSaw3.GetComponent<Saw>().shootDirection = shootDirection;
            }
            timer = 0;
        }
    }
}
