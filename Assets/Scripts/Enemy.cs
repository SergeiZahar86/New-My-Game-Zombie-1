using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float normalSpeed;
    public int damage; 
    private CharacterController character;
    private Animator anim;

    private void Start ()
    {
        anim = GetComponent<Animator> ();
        character = FindObjectOfType<CharacterController> ();
    }
    private void Update ()
    {
        if(health <= 0)
        {
            Destroy (gameObject); // уничтожаем врага если не осталось здоровья
        }
        transform.Translate (Vector2.right * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {      
        health -= damage;
    }
    public void OnEnemyAttack ()
    {
        character.ChangeHealth (-damage);
       
    }
}
