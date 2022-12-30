using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duoRing : MonoBehaviour
{
    public Ring[] ring = new Ring[2];
    public bool ringactive1;
    public bool ringactive2;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        ringactive1 = false;
        ringactive2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ring[0].ringActive == true)
        {
            ringactive1 = true;
                
        }

            if (ring[1].ringActive == true)
            {
            ringactive2 = true;
            }

        if (ringactive1 == true && ringactive2 == true)
        {
            //Debug.Log("rings active");
            OpenDoor();
        }
        
    }

    public void OpenDoor()
    {
        //Debug.Log("opendoor");
        Door.SetActive(false);
    }

}
