using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;

    public GameObject[] enemies;




    void Start()
    {
        //StartCoroutine (SpawnAnEnemy ());
    }
    private void Update ()
    {
        StartCoroutine (SpawnAnEnemy ());
    }

    IEnumerator SpawnAnEnemy ()
    {
        Vector2 spawnPos = GameObject.Find ("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate (enemies[EnemyChoice ()], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds (time);
        StartCoroutine (SpawnAnEnemy ());
    }
    private int EnemyChoice () // выбор врага
    {
        int random = Random.Range (1, 100);
        if(random <= 60)
        {
            return 0;
        }
        else if(random > 60 && random <= 90)
        {
            return 1;
        }
        else
        {
            return 2;
        }

    }
}
