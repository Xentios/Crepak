using Paulos.Projectiles;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform characterVisual;

    [SerializeField]
    private int ammo=10;

    [SerializeField]
    private int clipSize=10;

    [SerializeField]
    private float reloadTimer=2f;
    private float timePassed=0f;

    private bool shootRequest;

    [SerializeField]
    private float fireRate = 0.3f;
    private float lastShootTime = 0f;

    public void Update()
    {
        if (ammo <= 0)
        {
            timePassed += Time.deltaTime;
            if(timePassed > reloadTimer)
            {
                ammo = clipSize;
                timePassed = 0;
            }

            return;
        }

        lastShootTime-=Time.deltaTime;
        if (shootRequest && lastShootTime<0)
        {
            Projectile_Manager._Instance.FireProjectileForward("Projectile_Bullet_S", characterVisual);
            ammo--;
            shootRequest = false;
            lastShootTime = fireRate;

        }
    }

    public void Shoot()
    {
        shootRequest = true;
        
    }
}
