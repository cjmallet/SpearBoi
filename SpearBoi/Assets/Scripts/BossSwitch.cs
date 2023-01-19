using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject spearSpawnPoint;

    [SerializeField]
    private GameObject leverCage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            collision.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collision.transform.position = spearSpawnPoint.transform.position;
            Destroy(leverCage);
        }
    }
}
