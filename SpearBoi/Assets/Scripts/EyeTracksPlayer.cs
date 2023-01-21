using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracksPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private float offsetY=15;

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerY = player.transform.position.y - offsetY;

        if (!BossManager.Instance.isDying)
        {
            if (playerY<0)
            {
                playerY =0;
            }
            else if (playerY > 5)
            {
                playerY = 5;
            }

            float eyeBallY = (playerY * 0.16f)-0.4f;

            transform.localPosition = new Vector2(0, eyeBallY);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
