using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private Rigidbody2D rb;
    bool running = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            running = !running;
        }

        if (running)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

    }
}
