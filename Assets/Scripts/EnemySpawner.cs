using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(2, 5)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyparentTransform;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawningEnemies());
    }

    IEnumerator RepeatedlySpawningEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyparentTransform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
