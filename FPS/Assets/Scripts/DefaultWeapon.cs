using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : BaseWeapon {


    // Use this for initialization
    void Start () {

        currentBullets = 3;

        range = 100f;

        bulletsPerMag = 3;
        bulletsLeft = 200;
        currentBullets = 5;
        fireRate = 0.1f;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        base.info = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckFire();
        base.CheckReload();
    }

    protected void CheckFire()
    {

        Debug.DrawRay(shootPoint.position, shootPoint.transform.forward, Color.red);

        if (Input.GetButton("Fire1") && fireTimer > fireRate && currentBullets > 0 && !IsReloading())
        {
            Fire();
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    public void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)) {
            
        }

        anim.CrossFadeInFixedTime("Fire", fireRate);

        fireTimer = 0;
        currentBullets--;

    }
    
}
