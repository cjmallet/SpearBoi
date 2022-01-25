using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]public bool spearActivated;
    [HideInInspector] public bool playerActivated;

    public virtual void Activate()
    {

    }

    public virtual void Deactivate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.transform.CompareTag("Player") && !playerActivated))
        {
            playerActivated = true;
            Activate();
        }

        if (collision.transform.CompareTag("Spear") && !spearActivated)
        {
            spearActivated = true;
            Activate();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Spear") && spearActivated)
        {
            spearActivated = false;
            Deactivate();
        }

        if (collision.transform.CompareTag("Player") && spearActivated)
        {
            playerActivated = false;
            Deactivate();
        }
    }
}
