using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeToSpear : MonoBehaviour
{
    Transform transform;
    private int count = 0;
    public playerControler playerControler;
    public SpearThrowing spearThrowing;
    public GameObject spear;
    public GameObject arc;
    public GameObject blockEntrance;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
            blockEntrance.SetActive(true);
            Debug.Log("upgrade to spear");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
