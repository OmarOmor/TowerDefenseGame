using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TD_HUD : HUD
{

    [field: SerializeField]
    public TextMeshProUGUI HealthText { get; private set; }

    
    public GameObject WeaponUIPanel;
    public GameObject WeaponBtnPrefab;

    public static TD_HUD Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance    = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }


    public void AddWeaponToInventory()
    {

    }
   // public TextMeshProUGUI EnergyText;
}
