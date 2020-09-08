using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies; // массив врагов
    private float spawnRadius = 8; // радиус появления врагов
    public float time = 2; // время между появлением врагов
    private float coolDown = 2; // локальное время до спавна
    private int a = 0; // счетчик для уменьшения времени спавна
    void Update()
    {
        coolDown -= 1 * Time.deltaTime;
        if (coolDown <= 0)
        {
            a ++;
            if ((a % 10 == 0) && (time > 0.5))
            {
                time -= 0.1f;
            }
            coolDown = time;
            Instantiate (enemies[EnemyChoice ()], Random.insideUnitCircle.normalized * spawnRadius,
                 Quaternion.identity);
        }
    }
    private int EnemyChoice () // выбор врага
    {
        int random = Random.Range (1, 100);
        if (random <= 60)
        {
            return 0;
        }
        else if (random > 60 && random <= 90)
        {
            return 1;
        }
        else
        {
            return 2;
        }

    }
}
