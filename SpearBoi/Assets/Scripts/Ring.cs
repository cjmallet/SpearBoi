using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ringActive;

    SpriteRenderer switchSprite;
    [SerializeField]
    private GameObject door;


    public void Start()
    {
        ringActive = false;
        Deactivate();
    }

    public virtual void Activate()
    {
        ringActive = true;
        GetComponent<SpriteRenderer>().color = Color.green;
    }
    public virtual void Deactivate()
    {
        ringActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Spear"))
        {
            if (collision.GetComponent<Spear>().thrown)
            {
                switchState();
            }
        }
    }

    public void switchState() //Wordt aangeroepen wanneer de chain collision heeft met de switch
    {
        
        if (ringActive == false)
        {
            Activate();
            door.GetComponent<SpriteRenderer>().sprite = door.GetComponent<DoorScript>().doorOpen.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<BoxCollider2D>().enabled = false;
            ringActive = !ringActive;
        }
        else if (ringActive == true)
        {
            Deactivate();
            door.GetComponent<SpriteRenderer>().sprite = door.GetComponent<DoorScript>().doorClosed.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<BoxCollider2D>().enabled = true;
            ringActive = !ringActive;

        }
    }
}
