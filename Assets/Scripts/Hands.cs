using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public float offset; // величина для корректировки вращения рук
    public GameObject bullet; // создаём пулю
    public Transform shotPoint; // место откуда будет лететь пуля
    private float timeBtwShots;
    public float startTimeBtwShots; // время между выстрелами

    private void Update ()
    {
        //рассчитать положение курсора и повернуть в это направление оружие
        Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0f, 0f, rotZ + offset);
        // произвести выстрел и перезарядиться
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton (0))
            {
                Instantiate (bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        } 
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
