using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameModeBase GameMode;

    SpawnPoint defaultSpawnPoint;
    
    public WeaponManager WeaponManager;

    public static GameController Instance;

    public int Energy;

    private int maxEnergy = 100;

    public int health;
    private int maxHealth = 100;

    bool restartLevel = true;

    private void Awake()
    {
        defaultSpawnPoint = FindObjectsOfType<SpawnPoint>().LastOrDefault();
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

        WeaponManager = GetComponent<WeaponManager>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        SpawnPawn();
        SpawnHUD();
        Energy = maxEnergy;
        health = maxHealth;

    }


    private void Update()
    {
        if(health <= 0 && restartLevel)
        {
            TD_HUD.Instance.GameOverPanel.SetActive(true); 
            Time.timeScale = 0; // PAUSE the game
            restartLevel = false;
        }
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

    void SpawnHUD()
    {
        if(GameMode.DefaultHUD == null)
        {
            Debug.LogWarning("No HUD was assigned for " + GameMode.name);
        }else
        {
            var hud = Instantiate(GameMode.DefaultHUD) as TD_HUD;
            hud.name = "Tower Defense HUD";
            WeaponManager.WeaponUIPanel = hud.WeaponUIPanel;

            

        }
    }
}
