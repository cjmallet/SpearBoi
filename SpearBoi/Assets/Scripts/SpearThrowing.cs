using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowing : MonoBehaviour
{
    private GameObject spear;
    private bool spearThrown;
    private Vector2 lookRotation;

    // Start is called before the first frame update
    void Start()
    {
        spear = transform.GetChild(0).gameObject;
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
            spear.GetComponent<Rigidbody2D>().velocity += lookRotation.normalized * 5;
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
}
