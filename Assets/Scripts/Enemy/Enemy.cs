using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public EnemyDescriptor EnemyDescriptor;

    [SerializeField]
    private int health;

    public NavMeshAgent Agent;
    public Transform Destination;


    [SerializeField]
    Slider healthSlider;
    

    private void Awake()
    {
        //health = EnemyDescriptor.MaxHealth;
    }


    private void Start()
    {
        
        healthSlider.value = health;
    }

    private void Update()
    {
        Agent.destination = Destination.position;
        healthSlider.value = health;
    }


    public void SetHealth(int health)
    {
        this.health -= health;
    }

    public int GetHealth()
    {
        return health;
    }
        
}
