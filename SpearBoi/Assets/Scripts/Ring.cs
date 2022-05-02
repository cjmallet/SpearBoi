using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ringActive;
    [SerializeField] private Material myMaterial;

    public void Start()
    {
        ringActive = false;
    }

    public void Update()
    {
        
    }
    public virtual void Activate()
    {
        ringActive = true;
        myMaterial.color = Color.green;

    }
    public virtual void Deactivate()
    {
        ringActive = false;
        myMaterial.color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            ringActive = true;
        }
    }
}
