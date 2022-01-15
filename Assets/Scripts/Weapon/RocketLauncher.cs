using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public override void Shoot(Transform shootPoint, Vector3 targetPoint)
    {
        if (CurrentRemainingBullets > 0)
        { 
            int ShootPoint = 6;
            Instantiate(Bullet, new Vector3(targetPoint.x, ShootPoint, targetPoint.z), Quaternion.identity);
            CurrentRemainingBullets--;
            base.Shoot(shootPoint, targetPoint);
        }
    }
}
