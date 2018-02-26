using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator anim;

    public float range = 100f;

    public int bulletsPerMag = 3;
    public int bulletsLeft = 200;
    public int currentBullets;

    public float fireRate = 0.1f;
    float fireTimer;


    public Transform shootPoint;
    public GameObject hitParticles;
    public GameObject bulletImpact;

    private bool isReloading;
    private AnimatorStateInfo info;

    public GameObject bulletObject;
    public Bullet bullet;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        bullet = bulletObject.GetComponent<Bullet>();
        currentBullets = 3;
    }

    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckFire();
        CheckReload();
    }

    void CheckFire() {

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

    void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentBullets < bulletsPerMag)
        {
            Reload();
        }
    }

    void Fire()
    {
        RaycastHit hit;

        /*if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "found");

            GameObject bulletImpactEffect = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            //GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            Destroy(bulletImpactEffect, 1f);
        

        }*/

        Debug.Log("Fire");

        GameObject bullet = Instantiate(bulletObject, shootPoint.position, shootPoint.rotation);
        Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();
        rigidBody.AddForce(4000 * shootPoint.forward);

        anim.CrossFadeInFixedTime("Fire", fireRate);

        fireTimer = 0;
        currentBullets--;

    }

    private bool IsReloading()
    {
        return info.IsName("Reload");
    }

    void Reload()
    {
        if (bulletsLeft <= 0) return;

        DoReload();

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }

    private void DoReload()
    {

        if (IsReloading()) return;

        anim.CrossFadeInFixedTime("Reload", fireRate);
    }
}
