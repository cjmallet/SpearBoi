using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowing : MonoBehaviour
{
    [SerializeField] private GameObject arcPoint;
    [SerializeField] private GameObject arcHolderObject;
    [SerializeField] private GameObject buttonPrompt;
    [SerializeField] private int throwingSpeed;
    [SerializeField] private int amountOfArcPoints;

    private GameObject[] arcPoints;
    private GameObject spear;
    private GameObject spearHolder;
    private bool spearThrown;
    private Vector2 lookRotation;
    private Vector3 spearHeldPosition;

    // Start is called before the first frame update
    void Start()
    {
        arcPoints = new GameObject[amountOfArcPoints];
        spear = transform.GetChild(0).gameObject;

        for (int x=0; x<arcPoints.Length;x++)
        {
            arcPoints[x] = Instantiate(arcPoint, spear.transform.position,Quaternion.identity,arcHolderObject.transform);
            arcPoints[x].SetActive(false);
        }
        
        spearHeldPosition = transform.GetChild(1).transform.localPosition;
        spearHolder = transform.GetChild(1).gameObject;
        spear.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spearThrown)
        {
            lookRotation = Camera.main.ScreenToWorldPoint(Input.mousePosition)-spear.transform.position;
            float lookAngle= Mathf.Atan2(lookRotation.y, lookRotation.x) * Mathf.Rad2Deg;
            spear.transform.rotation = Quaternion.Euler(0,0,lookAngle);
            spear.transform.position = spearHolder.transform.position;
            spear.transform.localScale = Vector3.one;
        }

        if (Input.GetKey(KeyCode.E) && buttonPrompt.activeSelf)
        {
            ResetSpear();
        }

        if (Input.GetKey(KeyCode.Mouse0)&&!spearThrown)
        {
            for (int x = 0; x < arcPoints.Length; x++)
            {
                arcPoints[x].transform.position = CalculateArcPoint((x+1) * 0.05f);
                arcPoints[x].SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && !spearThrown)
        {
            Debug.Log(spear.transform.rotation);
            if (spear.transform.rotation.z<-0.3f&&spear.transform.rotation.z>-1&&GetComponent<playerControler>().grounded)
            {
                spear.transform.position= new Vector3(spear.transform.position.x, spear.transform.position.y+4, spear.transform.position.z);
            }

            spear.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            spear.GetComponent<Rigidbody2D>().velocity += lookRotation.normalized * throwingSpeed;
            spear.GetComponent<Spear>().thrown = true;
            spearThrown = true;

            for (int x = 0; x < arcPoints.Length; x++)
            {
                arcPoints[x].SetActive(false);
            }
        }
    }

    private Vector2 CalculateArcPoint(float t)
    {
        Vector2 pointPosition = (Vector2)spear.transform.position+(lookRotation.normalized * throwingSpeed * t)+0.5f*(spear.GetComponent<Rigidbody2D>().gravityScale*Physics2D.gravity)*(t*t);
        return pointPosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (spearThrown&&collision.CompareTag("Spear"))
        {
            spear.GetComponent<EdgeCollider2D>().isTrigger = false;
        }
    }

    public void ResetSpear()
    {
        spear.GetComponent<EdgeCollider2D>().isTrigger = true;
        spear.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        spear.GetComponent<Spear>().ResetSpear();
        spearThrown = false;
    }
}
