using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class MachineGun : WeaponBase
{

    float nextTimeToFire = 0;

    public AudioSource FireAudio;


    public override void FireProjectile()
    {
       if(CurrentTarget != null)
        {
            if(Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / WeaponDescriptor.FireRate;
                FireParticle.Play();
                FireAudio.Play();
                Projectile projectile = Instantiate(WeaponDescriptor.ProjectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Projectile;
                projectile.ChaseTarget(CurrentTarget);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



}
