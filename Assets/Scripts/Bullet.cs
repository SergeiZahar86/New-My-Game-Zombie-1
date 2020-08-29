﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // скорость пули
    public float lifetime; // время жизни пули
    public float distance; // расстояние полёта пули
    public int damage; // урон
    public LayerMask whatIsSolid; // задаёт слои для пробития
    public GameObject destroyEffect;
    private void Start ()
    {
        Destroy (gameObject, lifetime);
    }

    private void Update ()
    {
        // найти объект для пробития
        RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, transform.right, distance, whatIsSolid);
        // если пуля столкнулась с каким-нибудь коллайдером и у него тег "Эними" (наш враг), 
        // то мы наносим этому врагу урон
       
            if (hitInfo.collider != null && hitInfo.collider.CompareTag ("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy> ().TakeDamage (damage);
            }
        // движение патрона
        transform.Translate (Vector2.right * speed * Time.deltaTime);
    }
  

}
