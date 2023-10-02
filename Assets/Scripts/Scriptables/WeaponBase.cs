using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    
    public Transform WeaponRotator;

    [SerializeField]
    protected List<Transform> projectileSpawnPoints;

    [SerializeField]
    protected float scanRadius = 5.0f;

    [SerializeField]
    public Transform target;

    [SerializeField]
    public float targetDist;

    [field: SerializeField]
    public Transform CurrentTarget { get; set; }

    public abstract void AimAtTarget();

    public abstract void FireProjectile();



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }


}

