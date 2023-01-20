using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpHeight;
    private float moveInput;
    public Spear spear;

    private Rigidbody2D rb;
    private bool facingRight = true;

    [HideInInspector]
    public bool grounded;
    public bool onSpear;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask spearCheck;
    
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
        if(grounded || (onSpear && spear.thrown))
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;

        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && grounded)
        {
            if (spear.thrown)
            {
                rb.velocity = Vector2.up * jumpHeight;
            }
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        onSpear = Physics2D.OverlapCircle(groundCheck.position, checkRadius, spearCheck);
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
