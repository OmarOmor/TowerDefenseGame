using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform chaseTargetTransform;
    public float ProjectileSpeed = 20;
    public int Damage = 20;


    private void Update()
    {
        if(chaseTargetTransform != null)
        {
            Vector3 direction = chaseTargetTransform.position - transform.position;
            float dist = ProjectileSpeed * Time.deltaTime;

            transform.Translate(direction.normalized * dist,Space.World);

            if(direction.magnitude <=  dist)
            {
                Enemy  enemy  = chaseTargetTransform.GetComponent<Enemy>();
                if(enemy.GetHealth() > 0 )
                {
                    enemy.SetHealth(Damage);
                }else
                {
                    Destroy(enemy.gameObject);
                }
                
                Destroy(gameObject);
            }

        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void ChaseTarget(Transform target)
    {
        chaseTargetTransform = target;
    }
}
