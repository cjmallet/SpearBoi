using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowing : MonoBehaviour
{
    [SerializeField] private int throwingSpeed;

    private GameObject spear;
    private bool spearThrown;
    private Vector2 lookRotation;
    private Vector3 spearHeldPosition;

    // Start is called before the first frame update
    void Start()
    {
        spear = transform.GetChild(0).gameObject;
        spearHeldPosition = transform.GetChild(1).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spearThrown)
        {
            lookRotation = Camera.main.ScreenToWorldPoint(Input.mousePosition)-spear.transform.position;
            float lookAngle= Mathf.Atan2(lookRotation.y, lookRotation.x) * Mathf.Rad2Deg;
            spear.transform.rotation = Quaternion.Euler(0,0,lookAngle);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)&&!spearThrown)
        {
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && !spearThrown)
        {
            spear.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            spear.GetComponent<Rigidbody2D>().velocity += lookRotation.normalized * throwingSpeed;
            spearThrown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (spearThrown&&collision.CompareTag("Spear"))
        {
            spear.GetComponent<BoxCollider2D>().isTrigger = false;
            spear.GetComponentInChildren<EdgeCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spearThrown && collision.gameObject.CompareTag("Spear"))
        {
            spear.GetComponent<BoxCollider2D>().isTrigger = true;
            spear.GetComponentInChildren<EdgeCollider2D>().isTrigger=true;
            spear.transform.position =spearHeldPosition;
            spear.transform.parent = transform;
            spear.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            spearThrown = false;
        }
    }
}
