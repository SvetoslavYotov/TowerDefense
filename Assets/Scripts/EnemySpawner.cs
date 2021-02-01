using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawningEnemies());
    }

    IEnumerator RepeatedlySpawningEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
