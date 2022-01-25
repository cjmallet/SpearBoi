using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpHeight;

    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x+(movementSpeed*Time.deltaTime), transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - (movementSpeed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2Int(0,jumpHeight);
            grounded = false;
        }

        if (Physics2D.Raycast(transform.position,-Vector2.up,100))
        {
            grounded = true;
        }
    }
}
