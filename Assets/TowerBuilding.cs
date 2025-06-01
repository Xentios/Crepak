using UnityEngine;

using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;

public class TowerBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject TowerPrefab;

    [SerializeField] 
    private Transform TowerSpawnTarget;


    [SerializeField]
    private MinionManager minionManager;

    [SerializeField]
    private float upgradeSpeed = 1f;

    [SerializeField]
    private float upgradePersentange = 99f;

    [SerializeField]
    public List<GameObject> minionsWorking;

    private void OnEnable()
    {
        transform.DOMoveY(1, 1f);
    }

    private void Update()
    {
        upgradePersentange += Time.deltaTime * upgradeSpeed * minionsWorking.Count;
        if(upgradePersentange > 100f ) {
            GameObject.Instantiate(TowerPrefab, TowerSpawnTarget.position, TowerSpawnTarget.rotation);
            upgradePersentange = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Order")==false)  return;

       if(minionsWorking.Count >= 2 ) {
            minionManager.ReturnMinions(minionsWorking);

        }
        else
        {
            var newMinion=minionManager.GetAMinion();
            if(newMinion!=null)
            {
                minionsWorking.Add(newMinion);

            }
        }
    }
}
