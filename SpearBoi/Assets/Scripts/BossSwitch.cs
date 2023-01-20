using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject spearSpawnPoint;

    [SerializeField]
    private GameObject leverCage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            collision.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            collision.transform.position = spearSpawnPoint.transform.position;
            collision.transform.rotation = Quaternion.Euler(0,0,-90);
            Destroy(leverCage);
        }
    }
}
