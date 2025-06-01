using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private float dmgTakenPerBullet = 20f; 

    private AILerp ai;
    [SerializeField] 
    private Animator animator;

    [SerializeField]
    private GameObject Target;



    [SerializeField]
    private GameEvent enemyDied;

    private void Awake()
    {
        ai=GetComponent<AILerp>();
    }
    void Start()
    {
        ai.destination = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        animator.SetFloat("Velocity", ai.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= dmgTakenPerBullet;
            if(health < 0)
            {
                enemyDied.TriggerEvent();
                GameObject.Destroy(gameObject);
            }
        }
    }
}
