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
