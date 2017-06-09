using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    void Start()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemy.transform.parent = transform;
    }

    void Update()
    {

    }
}
