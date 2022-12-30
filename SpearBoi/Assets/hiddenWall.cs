using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.transform.tag == "Player"){
            gameObject.SetActive(false);
            Debug.Log("if trigger");
        }
    }
}
