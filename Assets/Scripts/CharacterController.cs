using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int health;
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
    // функция изменения здоровья
    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }

}
