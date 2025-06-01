using UnityEngine;

public class FireFromTower : MonoBehaviour
{

    [SerializeField]
    FireProjectile FireProjectile;

    private GameObject currentTarget;

    [SerializeField] float fireTimer = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) return;

        if(currentTarget == null)
        {
            currentTarget=other.gameObject;
        }
        //FireProjectile.FireHoming(currentTarget.transform);
    }

    private void Update()
    {
        if(currentTarget!= null && fireTimer>10f)
        {
            FireProjectile.FireHoming(currentTarget.transform);
            fireTimer = 0;
        }
        fireTimer += Time.deltaTime;
    }
}
