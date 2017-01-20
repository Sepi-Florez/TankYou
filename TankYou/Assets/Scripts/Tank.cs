using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public int ammoCount = 3;
    public int health = 100;
    public GameObject bulletPref;
    public float reloadTime;
    public float shootInterval;
    public Transform[] tankParts;
    bool shoot = true;
    float turnSpeed;
    public float turnSpeedO;
    public float rideSpeed;


	void Update () {
        Movement();
	}
    void Movement() {
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical" ) < 0) {
            turnSpeed = turnSpeedO / 2;
        }
        else {
            turnSpeed = turnSpeedO;
        }
        transform.Translate(0, Input.GetAxis("Vertical") * rideSpeed, 0);


        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * turnSpeed);
    }
    
}
