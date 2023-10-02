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

    [SerializeField] GameObject WeaponObject;
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

        if(WeaponObject == null)
        {
            Debug.LogError("No weapon object assigned to " + gameObject.name);
            return;
        }

        if(!IsTaken)
        {
            seatMesh.transform.DOShakeScale(1f, 0.25f);
            var weapon = Instantiate(WeaponObject);
            Utils.SetCurrentTransform(weapon.transform, this.transform,false);
            seatMesh.material.color = MouseEnterColor;
            IsTaken = true;

        }

    }
}
