using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public int health; // здоровье
    private Vector2 moveDirection;  // считывает в какую сторону мы движемся
    private Transform handsTransform; // Transform для рук
    private Transform legsTransform; // Transform для ног
    private Transform headTransform; // Transform для головы
    private Transform bodyTransform; // Transform для тела
    private Animator handsAnimation; // анимация рук
    private Animator runningAnimation; // анимация бега
    //для стрельбы
    public GameObject Bullet; // создаём пулю
    public Transform shotPoint; // место откуда будет лететь пуля
    private float timeBtwShots; // оставшееся время до выстрела
    public float startTimeBtwShots; // время между выстрелами

    private void Awake () // Awake всегда вызывается перед любой функцией Start. Используйте Awake 
    //для инициализации переменных или состояний перед запуском приложения. Unity вызывает Awake 
    //только один раз за время существования экземпляра скрипта.
    {
        bodyTransform = transform.Find ("Body");
        handsTransform = transform.Find ("Hands");
        headTransform = transform.Find ("Head");
        legsTransform = transform.Find ("Legs");
        handsAnimation = handsTransform.GetComponent<Animator> ();
        runningAnimation = GetComponent<Animator> ();
    }
    private void Update ()
    {
        MirroringBodyPartsAndAiming (handsTransform, true); // метод слежения рук и головы за мышью
        MirroringBodyPartsAndAiming (headTransform, true); // ... головы
        MirroringBodyPartsAndAiming (bodyTransform, false); // ... тела
        MirroringBodyPartsAndAiming (legsTransform, false); // ... ног
        RunningAnimation (); // анимация бега
        HandsAnimation (); // анимация стрельбы
        Shooting (); //стрельба префабами
    }

    private void FixedUpdate ()
    {
        Move (); // метод перемещение героя
    }
    private void Move () // метод перемещение героя
    {
        moveDirection = new Vector2 (Input.GetAxisRaw ("Horizontal"), 
            Input.GetAxisRaw ("Vertical")).normalized;
        rb.velocity = new Vector2 (moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void MirroringBodyPartsAndAiming (Transform bodyParts, bool NeedForRotationAround_Z) /* метод 
     разворота спрайтов влево и вправо за мышью. bool NeedForRotationAround_Z - необходимость вращения 
     спрайта за мышью вокруг оси Z. */
    {
        Vector3 mousePosition = GetMouseWorldPosition (Input.mousePosition, Camera.main);
        Vector3 handsDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2 (handsDirection.y, handsDirection.x) * Mathf.Rad2Deg;

        Vector3 LocalScale = Vector3.one;
        if (NeedForRotationAround_Z)
        {
            bodyParts.eulerAngles = new Vector3 (0, 0, angle); // слежение за мышью вокруг z
            if (angle > 90 || angle < -90)
            {
                LocalScale.y = -1f;
            }
            else
            {
                LocalScale.y = +1f;
            }
            bodyParts.localScale = LocalScale;
        }
        else
        {
            if (angle > 90 || angle < -90)
            {
                LocalScale.x = -1f;
            }
            else
            {
                LocalScale.x = +1f;
            }
            bodyParts.localScale = LocalScale;
        }
    }
    private Vector3 GetMouseWorldPosition (Vector3 screenPosition, Camera worldCamera) /* метод 
    определения положения курсора мыши в мировом пространстве. */
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint (screenPosition);
        //return worldPosition;
        worldPosition.z = 0f;
        return worldPosition;
    }
    private void Shooting () //стрельба префабами
    {
        if (timeBtwShots <= 0) // если оставшееся время до выстрела истекло
        {
            if (Input.GetMouseButton (0))
            {
                Instantiate (Bullet, shotPoint.position, handsTransform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void HandsAnimation () // анимация стрельбы
    {
        if (Input.GetMouseButton (0))
        {
            handsAnimation.SetBool ("Shoot", true);
        }
        else
        {
            handsAnimation.SetBool ("Shoot", false);
        }
    }
    private void RunningAnimation () // анимация бега
    {
        if ((moveDirection.x == 0) & (moveDirection.y == 0))
        {
            runningAnimation.SetBool ("isRunning", false);
        }
        else
        {
            runningAnimation.SetBool ("isRunning", true);
        }
    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health--;
            if(health == 0)
            {
                Destroy (gameObject);
            }
        }
    }


    /*
    public void TakeDamage (int damage)
    {
        //stopTime = startStopTime;
        // Instatiete(deathEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
    */

}
