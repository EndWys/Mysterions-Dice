using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    public bool on_ground = true;
    bool on_rope;

    int velocity = 50;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        anim.SetBool("Walck", false);

        if (on_rope)
            velocity = 30;
        else if (!on_ground)
            velocity = 50;
        else
            velocity = 85;

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * velocity);
            anim.SetBool("Walck", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * velocity);
            anim.SetBool("Walck", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (on_ground)
            {
                anim.Play("Jump");
                rb.AddForce(Vector2.up * 3000);
                on_ground = false;
                FindObjectOfType<AudioManager>().Play("Jump");
                transform.GetChild(0).SendMessage("Jump_failed");
            }
        }

        if (on_rope)
        {
            if (Input.GetKey(KeyCode.W))
                rb.AddForce(Vector2.up * velocity);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(Vector2.down * velocity / 2);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "rope")
        {
            on_rope = true;
            on_ground = false;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "rope")
        {
            on_rope = false;
            rb.gravityScale = 3;
        }
    }
}
