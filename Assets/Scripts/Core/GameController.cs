using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameModeBase GameMode;

    SpawnPoint defaultSpawnPoint;

    public static GameController Instance;


    private void Awake()
    {
        defaultSpawnPoint = FindObjectsOfType<SpawnPoint>().LastOrDefault();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnPawn();
    }


    void SpawnPawn()
    {
        if (GameMode.DefaultPawn == null)
        {
            Debug.LogError("No pawn found in game mode scriptable.Spawning Default Camera to spawn point");

            Camera cam = new GameObject("Camera").AddComponent<Camera>();

            Utils.SetCurrentTransform(cam.transform, defaultSpawnPoint.transform);
        }
        else
        {
            Pawn pawn = Instantiate(GameMode.DefaultPawn) as Pawn;
            pawn.name = "Player";
            if(defaultSpawnPoint == null)
            {
                Debug.LogError("No default spawn point found.Please add a spawn point prefab in your scene!");
            }else
            {
                Utils.SetCurrentTransform(pawn.transform, defaultSpawnPoint.transform);
            }
            
        }
    }
}
