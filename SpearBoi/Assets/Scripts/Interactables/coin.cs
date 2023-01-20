using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int coinValue;

    [SerializeField]
    private bool falling;
    
    // Start is called before the first frame update
    void Start()
    {
        if (falling)
        {
            GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }   
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            CoinManager.Instance.UpdateCoinCounter(coinValue);
        }
    }
}
