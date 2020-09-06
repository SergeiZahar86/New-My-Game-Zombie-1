using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack; // время перезарядки
    public float startTimeBtwAttack; // оставшееся время до выстрела
    public int damage; // урон который он наносит
    public float startStopTime; // время остановки после получения урона
    private float stopTime; // оставшееся время до возобновления движение врага после получения урона
    public float normalSpeed;
    private Player player;
    private Animator anim;


    public float speed;
    public int health;
    private Transform playerPos;
    private bool FlagToTurn = true; // флаг для поворота
    public bool SpritePointingToTheRight; // true - если спрайт изначально направлен вправо

    private void Start () // новое
    {
        anim = GetComponent<Animator> ();
        player = FindObjectOfType<Player> ();
        normalSpeed = speed;
    }

    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    private void Update ()
    {
        if(stopTime <= 0) // для остановки после получения урона
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }






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
        if(health <= 0) // если жизни кончились то смерть
        {
            Destroy (gameObject);
        }
    }
    public void TakeDamage(int damage) // получение урона
    {
        stopTime = startStopTime; // останавливается при получении урона
        // Instatiete(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
    private void Flip () // разворот спрайта по y
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }



    /*
    // новое. 
    // если столкнулись с игроком то активируется триггер атаки
    public void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetTrigger ("enemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;

            }
        }
    }
    public void OnEnemyAttack ()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
    */
}
