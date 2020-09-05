using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigZombie : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private bool FlagToTurn = true; // флаг для поворота

    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    private void Update ()
    {
        transform.position = Vector2.MoveTowards (transform.position, playerPos.position, speed * Time.deltaTime);
        if (playerPos.position.x > transform.position.x && FlagToTurn)
        {
            Flip ();
            FlagToTurn = false;
        }
        else if(playerPos.position.x < transform.position.x && !FlagToTurn)
        {
            Flip ();
            FlagToTurn = true;
        }
    }
    private void Flip () // разворот спрайта по y
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
