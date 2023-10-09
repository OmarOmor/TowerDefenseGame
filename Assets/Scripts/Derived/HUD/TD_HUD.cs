using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TD_HUD : HUD
{

    [field: SerializeField]
    public TextMeshProUGUI HealthText { get; private set; }


    [field: SerializeField]
    public TextMeshProUGUI EnergyText { get; private set; }

    [field: SerializeField]
    public GameObject GameOverPanel { get; private set; }



    public GameObject WeaponUIPanel;
    public GameObject WeaponBtnPrefab;


    public FixedTouchField TouchField;

    public static TD_HUD Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance    = this;
           // DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }


   public void RestartLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
