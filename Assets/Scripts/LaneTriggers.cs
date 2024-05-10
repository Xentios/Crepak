using Unity.VisualScripting;
using UnityEngine;

public class LaneTriggers : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        Debugger.Log(other.ToSafeString(),Debugger.PriorityLevel.Medium);
      
        other.transform.LookAt(other.transform.position+transform.forward,transform.up);                  
      
    }

    private void OnTriggerExit(Collider other)
    {
     
    }
}
