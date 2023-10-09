using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public EnemyDescriptor EnemyDescriptor;

    [SerializeField]
    private float health;

    public NavMeshAgent Agent;
    public Transform Destination;


    [SerializeField]
    Slider healthSlider;


    [SerializeField]
    float deltaDistance;
    

    private void Awake()
    {
        health = EnemyDescriptor.MaxHealth;
    }


    private void Start()
    {
        
        healthSlider.value = health;
        Destination = GameObject.FindGameObjectWithTag("Destination").transform;
    }

    private void Update()
    {
        Agent.destination = Destination.position;
        healthSlider.value = health;
        deltaDistance = Vector3.Distance(transform.position, Destination.position);
        if (deltaDistance <= (Agent.stoppingDistance + 0.5))
        {
            GameController.Instance.health -= 30;
            TD_HUD.Instance.HealthText.text = GameController.Instance.health.ToString();
            Destroy(gameObject);

        }
     
    }


    public void SetHealth(float health)
    {
        this.health -= health;
    }

    public float GetHealth()
    {
        return health;
    }
        
}
