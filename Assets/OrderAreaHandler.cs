using UnityEngine;
using DG.Tweening;

public class OrderAreaHandler : MonoBehaviour
{

    private int activationCounter= 0;

    [SerializeField]
    Collider shephereCollider;

    [SerializeField]
    float duration = 0.3f;

    private void OnEnable()
    {
        shephereCollider.enabled = true;
        transform.DOScale(new Vector3(6, 0.1f, 6), duration).OnComplete(DisableActions); ; ; 
    }

    private void OnDisable()
    {
        
    }

    private void DisableActions()
    {
        shephereCollider.enabled = false;
        transform.localScale= new Vector3(0,0.1f,0);
        gameObject.SetActive(false);
    }
}
