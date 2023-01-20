using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int coinValue;

    public bool falling;

    [SerializeField]
    private float maxSpeed=2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (falling)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<CircleCollider2D>().isTrigger = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(maxSpeed*0.3f, maxSpeed)));
            this.gameObject.isStatic = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            CoinManager.Instance.UpdateCoinCounter(coinValue);
        }
    }
}
