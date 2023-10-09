using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponDescriptor> WeaponList;

    public GameObject WeaponUIPanel;


    public static WeaponManager Instance;

    public WeaponBase CurrentSelectedWeapon;

    public List<WeaponButton> WeaponBtnList;



    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        for(int i = 0; i < WeaponList.Count; i++)
        {
            WeaponButton btn = Instantiate(TD_HUD.Instance.WeaponBtnPrefab.GetComponent<WeaponButton>(),WeaponUIPanel.transform);
            WeaponBtnList.Add(btn);
        }

        for(int i  = 0; i < WeaponList.Count;i++)
        {
            WeaponBtnList[i].weaponIndex = i;
            WeaponBtnList[i].GetComponent<Image>().sprite = WeaponList[i].WeaponUI_Icon;
        }
    }
}
