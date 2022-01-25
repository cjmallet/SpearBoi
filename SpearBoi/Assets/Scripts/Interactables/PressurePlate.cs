using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]public bool activated;

    public virtual void Activate()
    {
        activated = true;
    }

    public virtual void Deactivate()
    {
        activated = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.transform.CompareTag("Player") || collision.transform.CompareTag("Spear")) && !activated)
        {
            Activate();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("Player") || collision.transform.CompareTag("Spear")) && activated)
        {
            Deactivate();
        }
    }
}
