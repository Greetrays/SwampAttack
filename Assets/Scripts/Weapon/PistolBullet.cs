using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : Bullet
{
    protected override void Move()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.World);
    }
}
