using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMachineGun : WeaponGun
{
    private bool _isShootingFullAuto;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (_isShootingFullAuto)
        {
            ShootBullet();
        }

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
        base.ShootBullet();
    }

    public void StartFullAuto()
    {
        _isShootingFullAuto = true;
    }

    public void StopFullAuto()
    {
        _isShootingFullAuto = false;
    }
}
