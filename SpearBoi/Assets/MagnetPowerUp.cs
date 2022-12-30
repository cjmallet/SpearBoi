using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : MonoBehaviour
{
    [SerializeField] private SpearThrowing spearThrowing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("magnetPlayer");
            spearThrowing.magnoSpear = true;
            gameObject.SetActive(false);
        }
    }
}
