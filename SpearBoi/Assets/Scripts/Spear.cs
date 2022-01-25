using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [HideInInspector] public bool thrown;
    public GameObject buttonPrompt;

    private bool hasHit, playerInRange;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit && thrown)
        {
            TrackMovement();
        }

        if (playerInRange && thrown)
        {
            buttonPrompt.transform.position = new Vector2(transform.position.x, transform.position.y+2);
            buttonPrompt.SetActive(true);
        }
        else
        {
            buttonPrompt.SetActive(false);
        }
    }

    private void TrackMovement()
    {
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!playerInRange)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& playerInRange)
        {
            playerInRange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Stickable"))
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        hasHit = true;
    }

    public void ResetSpear()
    {
        hasHit = false;
        thrown = false;
    }
}
