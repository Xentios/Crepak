using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private MinionManager minionManager;

    [SerializeField]
    private float deCaptureSpeed = 3f;

    [SerializeField]
    private bool isCaptured = false;

    [SerializeField]
    private float captureMaxTime = 10f;

    private int capturerCount;

    private float capturedTime;


    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
    }


    private void Update()
    {
        if (isCaptured == true) return;

        if (capturerCount > 0)
        {
            Debugger.Log("Capture Time: " + capturedTime, Debugger.PriorityLevel.Low);
            capturedTime += Time.deltaTime * capturerCount;
            if(capturedTime > captureMaxTime )
            {
                isCaptured=true;
                SpawnMinion();
            }

        }
        else
        {
            capturedTime -= Time.deltaTime * deCaptureSpeed;
            if (capturedTime < 0) 
            {
            capturedTime= 0;
            }
        }
        meshRenderer.material.color =new Color( 1f - capturedTime / captureMaxTime, 1f, 1.0f - capturedTime / captureMaxTime);
    }

    private void SpawnMinion()
    {
        minionManager.SpawnNewMinion(transform.position);
    }

    private void OnPreRender()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(  "Enemy")) return;
        if (other.CompareTag("Projectile")) return;

        capturerCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) return;
        if (other.CompareTag("Projectile")) return;
        capturerCount--;
    }
}
