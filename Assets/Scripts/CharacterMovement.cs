using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    void Update ()
    {
        ProcessInputs ();
    }
    private void FixedUpdate ()
    {
        Move ();
    }
    void ProcessInputs ()
    {
        moveDirection = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
    }
    void Move ()
    {
        rb.velocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
