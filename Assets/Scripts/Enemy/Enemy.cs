using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int Health;

    public NavMeshAgent Agent;
    public Transform Destination;


    private void Update()
    {
        Agent.destination = Destination.position;
    }


    public void SetHealth(int health)
    {
        Health -= health;
    }

    public int GetHealth()
    {
        return Health;
    }
        
}
