using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            BossManager.Instance.TakeDamage(BossManager.Direction.DOWN);
        }
    }
}
