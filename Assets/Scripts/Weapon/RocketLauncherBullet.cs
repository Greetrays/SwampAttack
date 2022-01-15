using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherBullet : Bullet
{
    protected override void Move()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);
    }
}
