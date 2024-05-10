using UnityEngine;

public class HubTriggers : MonoBehaviour
{

    [SerializeField]
    private GameEvent sideCameraENableEvent;

    [SerializeField]
    private GameEvent sideCameraDISableEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        sideCameraDISableEvent.TriggerEvent();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        sideCameraENableEvent.TriggerEvent();
    }

    private void OnCollisionEnter(Collision collision)
    {
        sideCameraDISableEvent.TriggerEvent();
    }

    private void OnCollisionExit(Collision collision)
    {
        sideCameraENableEvent.TriggerEvent();
    }
}
