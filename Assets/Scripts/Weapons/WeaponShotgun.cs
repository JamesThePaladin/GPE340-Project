using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponShotgun : WeaponGun
{
    [SerializeField, Tooltip("Amount of bullets fired with each trigger pull.")]
    protected float projectileCount;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void AttackStart()
    {
        base.AttackStart();
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }
    public override void ShootBullet()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            base.ShootBullet();
        }
    }
}
