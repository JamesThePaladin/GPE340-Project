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
        this.name = "Machine Gun";
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {

        base.Update();
    }

    public override void FixedUpdate()
    {
        if (_isShootingFullAuto)
        {
            if (currentAmmo > 0)
            {
                ShootBullet();
                CheckAndDoTracer(); 
            }
        }
        base.FixedUpdate();
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
