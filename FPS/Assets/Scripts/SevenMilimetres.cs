using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenMilimetres : Bullet {

    // Use this for initialization
    void Start()
    {
        this.type = BulletType.SevenMilimetres;
        this.force = 50;
        this.rigidBody = this.GetComponent<Rigidbody>();
    }
    
	
}
