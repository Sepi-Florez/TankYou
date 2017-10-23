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
    int[] curState;
    public float[] speeds;
    public float[] speeds2;
    float l;
    float r;

    public int playerNumber;
    void Awake() {
        for(int a = 0; a < anim.Length; a++) {
            anim[a] = transform.GetChild(a + 1).GetComponent<Animator>();
        }


    }

	void FixedUpdate () {
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
                    bullet.GetComponent<Bullet>().origin = playerNumber;
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
    // the time before you can shoot again
    public IEnumerator ShootInterval(float time) {
        yield return new WaitForSeconds(time);
            shoot = true;
        if(reloadTime == time) {
            ammoCount = 3;
        }

    }
    // This is activated by the collider thats hit. It'll sent the right information to the interface manager and also update the current health. 
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
    //This function makes the wheels animation a bit more realistic
    void CPTUpdate() {
        Vector2 moveState = new Vector2(Input.GetAxisRaw(inputStrings[0]), Input.GetAxisRaw(inputStrings[1]));

        if(moveState.y == 0) {
            if(moveState.x == -1) {
                anim[0].SetFloat("speed", speeds[1]);
                l = speeds[1];
                anim[1].SetFloat("speed", speeds[1]);
                r = speeds[1];
            }
            else if(moveState.x == 0) {
                anim[0].SetFloat("speed", 0);
                anim[1].SetFloat("speed", 0);
            }
            else if(moveState.x == 1) {
                anim[0].SetFloat("speed", speeds[0]);
                anim[1].SetFloat("speed", speeds[0]);
            }
        }
        else if(moveState.y == 1) {
            if (moveState.x == -1) {
                anim[0].SetFloat("speed", speeds[3]);
                anim[1].SetFloat("speed", speeds[1]);
            }
            else if (moveState.x == 1) {
                anim[0].SetFloat("speed", speeds[0]);
                anim[1].SetFloat("speed", speeds[2]);
            }
            else if (moveState.x == 0) {
                anim[0].SetFloat("speed", speeds[0]);
                anim[1].SetFloat("speed", speeds[1]);
            }
        }
        else if(moveState.y == -1) {
            if (moveState.x == -1) {
                anim[0].SetFloat("speed", speeds[1]);
                anim[1].SetFloat("speed", speeds[3]);
            }
            else if (moveState.x == 1) {
                anim[0].SetFloat("speed", speeds[2]);
                anim[1].SetFloat("speed", speeds[0]);
            }
            else if (moveState.x == 0) {
                anim[0].SetFloat("speed", speeds[1]);
                anim[1].SetFloat("speed", speeds[0]);
            }
        }
    }

}
    