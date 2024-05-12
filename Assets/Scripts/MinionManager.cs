using NUnit.Framework;
using Pathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;


    [SerializeField]
    private List<GameObject> minionsGameObjects;
    private List<IAstarAI> minions;

    [SerializeField]
    private GameObject minionPrefab;

    [SerializeField]
    private Vector3 offset = Vector3.one;

    private Vector3 lastMinionPositions;

    public void SpawnNewMinion(Vector3 position)
    {
       var result=GameObject.Instantiate(minionPrefab,position,Quaternion.identity);
       minionsGameObjects.Add(result);
       minions.Add(result.GetComponent<AILerp>());
    }

    private void Awake()
    {
        minions = new List<IAstarAI>();
    }
    void Start()
    {
        foreach (var go in minionsGameObjects)
        {
            IAstarAI ai = null;
            ai = go.GetComponent<AIPath>() == null ? ai : go.GetComponent<AIPath>();
            ai = go.GetComponent<AILerp>() == null ? ai : go.GetComponent<AILerp>();           
            if (ai != null)
            {
                minions.Add(ai);
            }

        }
    }

   
    void Update()
    {
        lastMinionPositions = player.position;
        offset = player.transform.forward;
        for (int i = 0; i < minions.Count; i++)
        {           
            minions[i].destination = (lastMinionPositions - 2*offset);
            lastMinionPositions = minions[i].position;
            offset = minionsGameObjects[i].transform.forward;
            if (minions[i].remainingDistance < float.Epsilon)
            {
                minions[i].rotation = Quaternion.LookRotation(player.transform.forward);
                minions[i].canMove = false;
            }
            else
            {
                minions[i].canMove = true;
            }
        }

    }
}
