using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    float spawnTime;
    public float minTime;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);
        Invoke("SpawnEnemy", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[index], transform.position, transform.rotation);

        spawnTime = Random.Range(minTime, maxTime);
        Invoke("SpawnEnemy", spawnTime);

    }
}
