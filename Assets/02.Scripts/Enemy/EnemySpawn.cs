using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform enemyMiddleSpawnPoint;
    public Transform enemyLeftSpawnPoint;
    public Transform enemyRightSpawnPoint;

    private void Start()
    {
        GameObject leftEnemy = Instantiate(enemyPrefab);
        leftEnemy.transform.position = enemyLeftSpawnPoint.position;

        GameObject rightEnemy = Instantiate(enemyPrefab);
        rightEnemy.transform.position = enemyRightSpawnPoint.position;

        GameObject middleEnemy = Instantiate(enemyPrefab);
        middleEnemy.transform.position = enemyMiddleSpawnPoint.position;
    }
}