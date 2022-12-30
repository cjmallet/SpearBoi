using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRing : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ringActive;
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

    public void switchState()
    {

        if (ringActive == false)
        {
            Activate();
            door.SetActive(false);
            ringActive = !ringActive;
        }
        else if (ringActive == true)
        {
            Deactivate();
            door.SetActive(true);
            ringActive = !ringActive;

        }
    }
}
