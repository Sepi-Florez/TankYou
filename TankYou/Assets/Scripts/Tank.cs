using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public int ammoCount = 3;
    public int health = 100;
    public GameObject bulletPref;
    public Transform bulletPos;
    public float reloadTime;
    public float shootInterval;
    public string[] inputStrings;
    bool shoot = true;

    float turnSpeed;
    public float turnSpeedO;
    public float rideSpeed;
    public float gunTurnSpeed;

    public Animator[] anim;


	void Update () {
        Movement();
        Shoot();
	}
    void Movement() {
        if(Input.GetAxis(inputStrings[0]) > 0 || Input.GetAxis(inputStrings[0]) < 0) {
            turnSpeed = turnSpeedO / 2;
        }
        else {
            turnSpeed = turnSpeedO;
        }
        transform.Translate(0, Input.GetAxis(inputStrings[0]) * rideSpeed, 0);


        transform.Rotate(0, 0, -Input.GetAxis(inputStrings[1]) * turnSpeed);
        transform.GetChild(0).Rotate(0, 0, Input.GetAxis(inputStrings[2]) * gunTurnSpeed);


        
    }
    void Shoot() {
        if (Input.GetButtonDown(inputStrings[3])) {
            if (shoot) {
                GameObject bullet = (GameObject)Instantiate(bulletPref, bulletPos.position, transform.GetChild(0).rotation);
                shoot = false;
                ammoCount--;
                if(ammoCount == 0)
                    StartCoroutine(ShootInterval(reloadTime));
                else
                    StartCoroutine(ShootInterval(shootInterval));
            }
        }
    }
    IEnumerator ShootInterval(float time) {
        yield return new WaitForSeconds(time);
        if (ammoCount == 0)
            ammoCount = 3;
        shoot = true;
    }
    public void Hit(int damage) {
        health -= damage;
        if (health <= 0)
            Death();
    }
    public void Death() {
        Destroy(transform.gameObject);
    }

}
    