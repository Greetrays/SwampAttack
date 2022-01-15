using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] private int _maxBullets;

    private int _currentBullets;

    public override void Shoot(Transform shootPoint, Vector3 targetPoint)
    {
        if (_currentBullets < _maxBullets)
        {
            int ShootPoint = 6;
            Instantiate(Bullet, new Vector3(targetPoint.x, ShootPoint, targetPoint.z), Quaternion.identity);
            _currentBullets++;
        }
    }
}
