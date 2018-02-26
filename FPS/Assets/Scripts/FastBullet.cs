using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBullet : BaseBullet {


	// Use this for initialization
	void Start () {
        type = BulletType.Fast;
        damage = DamageType.High;
        velocity = 5000;
	}

}
