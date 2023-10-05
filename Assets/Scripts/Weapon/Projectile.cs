using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject chaseTargetTransform;
    public float ProjectileSpeed = 20;
    public int Damage = 20;

    public Enemy enemy;


    private void Update()
    {
        if(chaseTargetTransform != null)
        {
            Vector3 direction = chaseTargetTransform.transform.position - transform.position;
            float dist = ProjectileSpeed * Time.deltaTime;

            transform.Translate(direction.normalized * dist,Space.World);

        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void ChaseTarget(Transform target)
    {
        chaseTargetTransform = target.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            enemy = chaseTargetTransform.GetComponent<Enemy>();
            Debug.Log("Enemy hit!!");
            enemy.SetHealth(Damage);
            Destroy(gameObject);
        }

    }
}
