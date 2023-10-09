using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class WeaponBase : MonoBehaviour
{
    
    public Transform WeaponRotator;

    public WeaponDescriptor WeaponDescriptor;

    [SerializeField]
    protected Transform projectileSpawnPoint;

    [SerializeField]
    protected float scanRadius = 5.0f;

    protected float fireRate;

    [SerializeField]
    public float targetDist;

    [field: SerializeField]
    public Transform CurrentTarget { get; set; }

    public ParticleSystem FireParticle;


    private void Awake()
    {
        fireRate = WeaponDescriptor.FireRate;
    }



    public void AimAtTarget()
    {
            Quaternion lookRotation = Quaternion.LookRotation(CurrentTarget.position - transform.position);

            WeaponRotator.transform.localRotation = Quaternion.Slerp(WeaponRotator.transform.localRotation, lookRotation, 5f * Time.deltaTime);

    }




    private void Update()
    {

        FindEnemies();

        if(CurrentTarget != null)
        {
        
              AimAtTarget();
            FireProjectile();
        }


    }

    void FindEnemies()
    {
        /*
         * Taken from https://www.youtube.com/watch?v=QKhn2kl9_8I    
        */

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= scanRadius)
        {
            CurrentTarget = nearestEnemy.transform;
            
        }
        else
        {
            CurrentTarget = null;
        }


    }

    public abstract void FireProjectile();



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }


   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            CurrentTarget = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentTarget = null;
    }
   */
}

