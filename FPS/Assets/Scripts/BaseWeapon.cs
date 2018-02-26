using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseWeapon : MonoBehaviour {

    protected Animator anim;
    protected BulletManager bM;

    public float range;

    public int bulletsPerMag;
    public int bulletsLeft;
    public int currentBullets;

    public FastBullet fastBullet;

    public float fireRate;
    public float fireTimer;

    public Transform shootPoint;

    protected bool isReloading;
    protected AnimatorStateInfo info;


    void Fire() { }

    

    protected void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentBullets < bulletsPerMag)
        {
            Reload();
        }
    }

    protected void Reload()
    {
        if (bulletsLeft <= 0) return;

        DoReload();

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }

    protected bool IsReloading()
    {
        return info.IsName("Reload");
    }

    protected void DoReload()
    {

        if (IsReloading()) return;

        anim.CrossFadeInFixedTime("Reload", fireRate);
    }

}
