using Unity.VisualScripting;
using UnityEngine;

public class LaneTriggers : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        Debugger.Log(other.ToSafeString(),Debugger.PriorityLevel.Medium);
        if (other.CompareTag("Player"))
        {
            other.transform.LookAt(other.transform.position+transform.forward,transform.up);
            other.transform.position *=2;
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
     
    }
}
