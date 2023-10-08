using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponDescriptor> WeaponList;

    public GameObject WeaponUIPanel;


    public static WeaponManager Instance;

    public WeaponBase CurrentSelectedWeapon;



    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        for (int i = 0; i < WeaponList.Count; i++)
        {
            GameObject wpnBtn = Instantiate(TD_HUD.Instance.WeaponBtnPrefab, WeaponUIPanel.transform);
        }
    }
}
