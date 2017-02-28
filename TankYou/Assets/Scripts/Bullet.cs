using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public GameObject smoke;
	// Use this for initialization
	void Start () {
        //GameObject particle = (GameObject)Instantiate(smoke, transform.position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed, 0);
	}
}
