using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float ThresholdTime;
    public bool resetTime;
    public Transform EnemySpawnTransform;

    public GameObject enemyPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
        ThresholdTime -= Time.deltaTime;
        ThresholdTime = Mathf.Clamp(ThresholdTime, 0.0f, 5.0f);

        if(resetTime)
        {
            ThresholdTime = 5;
            resetTime = false;
        }
    }


    void SpawnEnemies()
    {
        if(ThresholdTime <= 0.0f) 
        {
            Debug.Log("Enemy Spawned!");
            GameObject enemy = Instantiate(enemyPrefab);
            Utils.SetCurrentTransform(enemyPrefab.transform, enemy.transform);
            resetTime = true;
        }


    }
}
