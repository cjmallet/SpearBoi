using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeToSpear : MonoBehaviour
{
    Transform transform;
    private int count = 0;
    public playerControler playerControler;
    public SpearThrowing spearThrowing;
    public GameObject spear;
    public GameObject arc;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spear.SetActive(false);
        arc.SetActive(false);
        
        transform = gameObject.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spear.SetActive(true);
            arc.SetActive(true);
            spearThrowing.ResetSpear();
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
