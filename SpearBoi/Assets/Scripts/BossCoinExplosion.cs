using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoinExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject coins;

    [SerializeField]
    private int coinExplosions=40;

    [SerializeField]
    private float maxSpeed=200;

    private float timer, coinReleaseTime=0.1f, explosionAmount;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer>coinReleaseTime)
        {
            CoinExplosion();
            explosionAmount++;
            timer = 0;
        }

        if (explosionAmount == coinExplosions)
        {
            Destroy(this.gameObject);
        }
    }

    private void CoinExplosion()
    {
        GameObject spawnedCoin = Instantiate(coins, transform.position, transform.rotation, null);
        spawnedCoin.GetComponent<coin>().falling = true;
    }
}
