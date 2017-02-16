using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
    public int ammoCount = 3;
    public int[] health;
    public GameObject bulletPref;
    public Transform bulletPos;
    public float reloadTime;
    public float shootInterval;
    public string[] inputStrings;
    bool shoot = true;
    bool reload = false;

    float turnSpeed;
    public float turnSpeedO;
    public float rideSpeed;
    public float gunTurnSpeed;

    public Animator[] anim;

    public int playerNumber;
    void Awake() {
        for(int a = 0; a < anim.Length; a++) {
            anim[a] = transform.GetChild(a + 1).GetComponent<Animator>();
        }
    }

	void Update () {
        Movement();
        Shoot();
	}
    void Movement() {
        if(Input.GetAxis(inputStrings[0]) != 0){
            turnSpeed = turnSpeedO / 2;
        }
        else {
            turnSpeed = turnSpeedO;
        }
        transform.Translate(0, Input.GetAxis(inputStrings[0]) * rideSpeed, 0);



        transform.Rotate(0, 0, -Input.GetAxis(inputStrings[1]) * turnSpeed);
        transform.GetChild(0).Rotate(0, 0, Input.GetAxis(inputStrings[2]) * gunTurnSpeed);

        CPTUpdate(); 
        
    }
    void Shoot() {
        if (Input.GetButtonDown(inputStrings[3])) {
            if (shoot == true) {
                if (ammoCount > 0) {
                    ammoCount--;
                    shoot = false;
                    
                    GameObject bullet = (GameObject)Instantiate(bulletPref, bulletPos.position, transform.GetChild(0).rotation);
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<InterfaceManager>().ammoUpdate(playerNumber, ammoCount);
                    StartCoroutine(ShootInterval(shootInterval));
                }
                else {
                    reload = true;
                    shoot = false;
                }
            }
            if(reload == true){
                reload = false;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<InterfaceManager>().ammoUpdate(playerNumber, -1);
                StartCoroutine(ShootInterval(reloadTime));
            }
        }
    }
    public IEnumerator ShootInterval(float time) {
        yield return new WaitForSeconds(time);
            shoot = true;
        if(reloadTime == time) {
            ammoCount = 3;
        }

    }

    public void Hit(int damage, int part) {
        health[part] -= damage;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<InterfaceManager>().healthUpdate(playerNumber, health[part], part);
        for(int a =0; a < health.Length; a++) {
           if(health[a] <= 0) {
                if(a == 0) {
                    Death();
                }
                else {
                    print("wheels destroyed");
                }
           }
        }

    }
    public void Death() {
        Destroy(transform.gameObject);
        
    }
    void CPTUpdate() {
        anim[0].SetFloat("speed", Input.GetAxis(inputStrings[0]));
        anim[1].SetFloat("speed", Input.GetAxis(inputStrings[0]));
    }

}
    