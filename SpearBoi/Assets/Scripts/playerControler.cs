using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpHeight;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        grounded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;
            Debug.Log("Extra Jump" + extraJumps);
            Debug.Log(grounded);

        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && grounded == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
            Debug.Log("amount of Jumps" + extraJumps);
        }
    }

    private void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //press left moveInput == -1, press right moveInput == 1
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}
