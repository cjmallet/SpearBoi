using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [HideInInspector] public bool thrown;

    private bool hasHit;
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
    }

    private void TrackMovement()
    {
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
    }

    public void ResetSpear()
    {
        hasHit = false;
        thrown = false;
    }
}
