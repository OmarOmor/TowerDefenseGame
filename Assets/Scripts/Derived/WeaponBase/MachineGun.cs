using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MachineGun : WeaponBase
{
    public override void AimAtTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        WeaponRotator.transform.localRotation = Quaternion.Slerp(WeaponRotator.transform.localRotation,lookRotation,5f * Time.deltaTime);
    }

    public override void FireProjectile()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);

        if(targetDist < 20 )
        {
            AimAtTarget();
        }

    }


}
