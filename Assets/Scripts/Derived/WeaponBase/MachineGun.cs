using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class MachineGun : WeaponBase
{

    
    public override void FireProjectile()
    {
       if(CurrentTarget != null)
        {
            if(fireRate >= WeaponDescriptor.FireRate)
            {
                Debug.Log("Bang! bang!");
                fireRate = 0;
            }


            fireRate += Time.deltaTime * WeaponDescriptor.FireRate;
            fireRate = Mathf.Clamp(fireRate, 0, WeaponDescriptor.FireRate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



}
