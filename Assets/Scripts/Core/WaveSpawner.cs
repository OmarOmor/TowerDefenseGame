using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float WaveThresholdTime;
    public float WaveMaxThresholdTime = 5;
    public bool resetTime;
    public Transform EnemySpawnTransform;

    public GameObject enemyPrefab;

    public int MAX_LEVELS = 100;

    public int waveNumber = 0;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
        WaveThresholdTime -= Time.deltaTime;
        WaveThresholdTime = Mathf.Clamp(WaveThresholdTime, 0.0f, 5.0f);

        if(resetTime)
        {
            WaveThresholdTime = WaveMaxThresholdTime;
            resetTime = false;
        }
    }


    void SpawnEnemies()
    {
        if(WaveThresholdTime <= 0.0f) 
        {
            Debug.Log("Enemy Spawned!");
            
            StartCoroutine(SpawnWave());
            
            
            resetTime = true;
        }
    }


    IEnumerator SpawnWave()
    {
        waveNumber++;
        for(int i = 0; i < waveNumber;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab,EnemySpawnTransform.position,EnemySpawnTransform.rotation);
    }


    
}
