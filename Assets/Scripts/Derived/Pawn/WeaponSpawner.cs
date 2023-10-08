using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponSpawner : Pawn
{
    public Color MouseEnterColor;

    MeshRenderer seatMesh;

    [field: SerializeField]
    public bool IsTaken { get; set; }

    
    public void Start()
    {

        seatMesh = GetComponentInChildren<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        if(ReceiveInput)
        {

            seatMesh.material.DOColor(MouseEnterColor, 0.45f);
            
        }
        
    }

    private void OnMouseExit()
    {
        if (ReceiveInput && !IsTaken)
        {
            seatMesh.material.DOColor(Color.white, 0.45f);
        }
    }

    private void OnMouseUp()
    {    

        if(GameController.Instance.WeaponManager.CurrentSelectedWeapon == null)
        {
            //Debug.LogError("No weapon object assigned to " + gameObject.name);
            return;
        }else
        {
            if (!IsTaken)
            {
                seatMesh.transform.DOShakeScale(1f, 0.25f);
                var weapon = Instantiate(GameController.Instance.WeaponManager.CurrentSelectedWeapon.gameObject);
                Utils.SetCurrentTransform(weapon.transform, this.transform, false);
                weapon.transform.DOShakeScale(1f, 0.25f);
                seatMesh.material.color = MouseEnterColor;
                IsTaken = true;

            }

        }



    }
}
