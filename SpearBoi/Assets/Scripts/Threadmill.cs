using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threadmill : MonoBehaviour
{
    public Direction direction;
    public float directionMultiplier;

    [HideInInspector]
    public Vector2 directionVector;

    // Start is called before the first frame update
    void Start()
    {
        switch (direction)
        {
            case Direction.LEFT:
                directionVector = Vector2.left;
                break;
            case Direction.RIGHT:
                directionVector = Vector2.right;
                break;
            case Direction.UP:
                directionVector = Vector2.up;
                break;
            case Direction.DOWN:
                directionVector = Vector2.down;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CircleCollider2D>()!=collision)
        {
            if (collision.CompareTag("Spear"))
            {
                if (collision.GetComponent<Spear>().thrown)
                {
                    collision.transform.position = new Vector3(collision.transform.position.x + directionVector.x / (25 / directionMultiplier),
                    collision.transform.position.y + directionVector.y / (25/directionMultiplier), collision.transform.position.z);
                }
            }
            else if(collision.CompareTag("Player"))
            {
                collision.transform.position = new Vector3(collision.transform.position.x + directionVector.x / (25 / directionMultiplier),
                    collision.transform.position.y + directionVector.y / (25 / directionMultiplier), collision.transform.position.z);
            }
        }
    }

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}
