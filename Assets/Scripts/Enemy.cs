using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    private Transform playerPos;
    private bool FlagToTurn = true; // флаг для поворота
    public bool SpritePointingToTheRight; // true - если спрайт изначально направлен вправо

    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    private void Update ()
    {
        transform.position = Vector2.MoveTowards (transform.position, playerPos.position,
            speed * Time.deltaTime); // преследование игрока

        if (SpritePointingToTheRight) // разворот спрайта
        {
            if (playerPos.position.x < transform.position.x && FlagToTurn)
            {
                Flip ();
                FlagToTurn = false;
            }
            else if (playerPos.position.x > transform.position.x && !FlagToTurn)
            {
                Flip ();
                FlagToTurn = true;
            }
        }
        else
        {
            if (playerPos.position.x > transform.position.x && FlagToTurn)
            {
                Flip ();
                FlagToTurn = false;
            }
            else if (playerPos.position.x < transform.position.x && !FlagToTurn)
            {
                Flip ();
                FlagToTurn = true;
            }
        }
        if(health <= 0) // получение урона
        {
            Destroy (gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void Flip () // разворот спрайта по y
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
