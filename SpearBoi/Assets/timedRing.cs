using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedRing : MonoBehaviour
{
    public float amountTime;
    public bool timerOn;
    public ParticleSystem fire;
    // Start is called before the first frame update


    // Update is called once per frame
    private void Start()
    {
        fire.time = amountTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            if (collision.GetComponent<Spear>().thrown)
            {
                ActivateRing();
            }
        }
    }

    void Update()
    {
        if (timerOn)
        {
            if (amountTime > 0)
            {
                
                amountTime -= Time.deltaTime;
            }

            else
            {
                Debug.Log("time is up");
                amountTime = 0;
                timerOn = false;
            }
        }
    }

    void ActivateRing()
    {
        if (timerOn)
        {
            fire.Play();
        }
    }
}
