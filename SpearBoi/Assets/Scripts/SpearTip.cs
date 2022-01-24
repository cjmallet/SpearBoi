using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTip : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<Spear>().CheckCollision(collision);
    }
}
