using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float offset; // величина для корректировки вращения рук
    public float speed; // скорость пули
    public float lifetime; // время жизни пули
    public float distance; // расстояние полёта пули
    public int damage; // урон
    public LayerMask whatIsSolid; // задаёт слои для пробития

    private void Update ()
    {
        //рассчитать положение курсора и повернуть в это направление оружие
        Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0f, 0f, rotZ + offset);
        // найти объект для пробития
        RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, transform.up, distance, whatIsSolid);
        // если пуля столкнулась с каким-нибудь коллайдером и у него тег "Эними" (наш враг), 
        // то мы наносим этому врагу урон и уничтожаем пулю
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag ("Enemy"))
            {
               // hitInfo.collider.GetComponent<Enemy> ().TakeDamage (damage);
            }
            Destroy (gameObject);

        }
        // движение патрона
        transform.Translate (Vector2.up * speed * Time.deltaTime);
    }

}
