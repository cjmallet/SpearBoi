using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Boss"))
        {
            BossManager.Instance.TakeDamage();
            Instantiate(particles, transform.position, transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}
