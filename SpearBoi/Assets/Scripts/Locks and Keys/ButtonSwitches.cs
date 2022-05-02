using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ButtonSwitches : MonoBehaviour
{
    [SerializeField]
    private GameObject switchOn, switchOff;
    public GameObject player;
    [SerializeField]
    public GameObject door;

    SpriteRenderer switchSprite;



    public bool isOn = false;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        switchSprite = gameObject.GetComponent<SpriteRenderer>();

        if (isOn == false)
        {
            switchSprite.sprite = switchOff.GetComponent<SpriteRenderer>().sprite;

        }

        if (isOn == true)
        {

            switchSprite.sprite = switchOn.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void switchState() //Wordt aangeroepen wanneer de chain collision heeft met de switch
    {
        
        if (isOn == false)
        {
            switchSprite.sprite = switchOn.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<SpriteRenderer>().sprite = door.GetComponent<DoorScript>().doorOpen.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<BoxCollider2D>().enabled = false;
            isOn = !isOn;

        }
        else if (isOn == true)
        {
            switchSprite.sprite = switchOff.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<SpriteRenderer>().sprite = door.GetComponent<DoorScript>().doorClosed.GetComponent<SpriteRenderer>().sprite;
            door.GetComponent<BoxCollider2D>().enabled = true;
            isOn = !isOn;

        }
    }
}