using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    
    public Transform WeaponRotator;

    public WeaponDescriptor WeaponDescriptor;

    [SerializeField]
    protected List<Transform> projectileSpawnPoints;

    [SerializeField]
    protected float scanRadius = 5.0f;

    protected float fireRate;

    [SerializeField]
    public float targetDist;

    [field: SerializeField]
    public Transform CurrentTarget { get; set; }

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
        if(CurrentTarget != null)
        {
        
              AimAtTarget();
            FireProjectile();
        }


    }

    public abstract void FireProjectile();



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }


    private void OnTriggerEnter(Collider other)
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

}

