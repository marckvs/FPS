using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector] public enum BulletType { SevenMilimetres, FiveMilimetres};
    [HideInInspector] public BulletType type;
    [HideInInspector] public float force;
    [HideInInspector] public Rigidbody rigidBody;
}
