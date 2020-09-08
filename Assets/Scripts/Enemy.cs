using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float startTimeBtwAttack; // оставшееся время до выстрела
    public int damage; // урон который он наносит
    public float startStopTime; // время остановки после получения урона
    private float stopTime; // оставшееся время до возобновления движение врага после получения урона
    public float normalSpeed; // обычная скорость
    public float speed; // переменная для остановки
    public int health;// здоровье
    private Transform playerPos;
    private bool FlagToTurn = true; // флаг для поворота
    public bool SpritePointingToTheRight; // true - если спрайт изначально направлен вправо
    private void Start () 
    {
        normalSpeed = speed;
    }
    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    private void Update ()
    {
        transform.position = Vector2.MoveTowards (transform.position, playerPos.position,
            speed * Time.deltaTime); // преследование игрока
        StopAfterDamage (); // метод для остановки после получения урона
        EnemyTurn (); // разворот врага по оси Y
        EnemyDeath (); // смерть врага
    }
    private void StopAfterDamage () // метод для остановки после получения урона
    {
        if (stopTime <= 0) 
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }
    private void EnemyTurn () // разворот врага по оси Y
    {
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
    }
    public void TakeDamage(int damage) // получение урона
    {
        stopTime = startStopTime; // останавливается при получении урона
        health -= damage;
    }
    private void Flip () // разворот спрайта по y
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private void EnemyDeath () // смерть врага
    {
        if (health <= 0) 
        {
            ScoreManager.Instance.IncreaseScore(); // добавить очки
            Destroy (gameObject);
        }
    }
}
