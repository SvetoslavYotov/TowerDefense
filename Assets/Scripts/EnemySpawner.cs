using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(2, 5)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyparentTransform;
    int score = 0;
    [SerializeField] Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString(); 
        StartCoroutine(RepeatedlySpawningEnemies());
    }

    IEnumerator RepeatedlySpawningEnemies()
    {
        while (true)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyparentTransform;
            score++;
            scoreText.text = score.ToString();

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
