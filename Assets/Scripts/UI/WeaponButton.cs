using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    Button weaponSelectionBtn;
    [SerializeField]
    int weaponIndex;

    private void Start()
    {
        weaponSelectionBtn = GetComponent<Button>();
        weaponSelectionBtn.onClick.AddListener(SelectCurrentWeapon);

    }

    public void SelectCurrentWeapon()
    {
        WeaponManager.Instance.CurrentSelectedWeapon = WeaponManager.Instance.WeaponList[weaponIndex].WeaponVisualPrefab.GetComponent<WeaponBase>();

    }
}
