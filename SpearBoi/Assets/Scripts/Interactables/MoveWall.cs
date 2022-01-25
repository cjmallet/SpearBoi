using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : PressurePlate
{
    [SerializeField] private GameObject movingObject;
    [SerializeField] private int moveDistance;
    [SerializeField] private int moveSpeed;

    [SerializeField, Header("Left, Right, Up or Down")]
    private string moveDirection;
    private bool destinationReached=true;
    private Vector3 destination;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = movingObject.transform.localPosition;
    }

    private void Update()
    {
        if (!destinationReached)
        {
            movingObject.transform.localPosition = Vector3.MoveTowards(movingObject.transform.localPosition,destination,moveSpeed/1000f);
        }

        if (movingObject.transform.localPosition == destination)
        {
            destinationReached = true;
        }
    }

    public override void Activate()
    {
        base.Activate();

        switch (moveDirection)
        {
            case "Left":
                destination = new Vector3(startPosition.x - moveDistance, startPosition.y, 0);
                destinationReached = false;
                break;
            case "Right":
                destination = new Vector3(startPosition.x + moveDistance, startPosition.y, 0);
                destinationReached = false;
                break;
            case "Up":
                destination = new Vector3(startPosition.x, movingObject.transform.position.y + moveDistance, 0);
                destinationReached = false;
                break;
            case "Down":
                destination = new Vector3(startPosition.x, movingObject.transform.position.y - moveDistance, 0);
                destinationReached = false;
                break;
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();
      
        switch (moveDirection)
        {
            case "Left":
                destination = new Vector3(startPosition.x + moveDistance, startPosition.y, 0);
                destinationReached = false;
                break;
            case "Right":
                destination = new Vector3(startPosition.x - moveDistance, startPosition.y, 0);
                destinationReached = false;
                break;
            case "Up":
                destination = new Vector3(startPosition.x, movingObject.transform.position.y - moveDistance, 0);
                destinationReached = false;
                break;
            case "Down":
                destination = new Vector3(startPosition.x, movingObject.transform.position.y + moveDistance,0);
                destinationReached = false;
                break;
        }
    }
}
