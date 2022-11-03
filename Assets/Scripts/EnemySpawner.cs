using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawners;
    [SerializeField] GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spawner();
        }
    }

    public void Spawner()
    {
        for (int i = 0; i < enemySpawners.Length;i++)
        {
            Instantiate(enemy, enemySpawners[i].transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
