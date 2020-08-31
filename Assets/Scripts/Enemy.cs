using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;

    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    private void Update ()
    {
        transform.position = Vector2.MoveTowards (transform.position, playerPos.position,speed* Time.deltaTime);
    }
}
