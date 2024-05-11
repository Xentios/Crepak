using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;


    [SerializeField]
    private List<NavMeshAgent> minions;

    [SerializeField]
    private Vector3 offset=Vector3.one;

    private Transform lastMinion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastMinion = player;
        offset = player.transform.forward;
        for (int i = 0; i < minions.Count; i++)
        {
            minions[i].SetDestination(lastMinion.position- offset);
            lastMinion = minions[i].transform;
            offset=lastMinion.transform.forward;
        }
        
    }
}
