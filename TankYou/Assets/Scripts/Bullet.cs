using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public GameObject smoke;
    public int origin;


    void Start () {
        //GameObject particle = (GameObject)Instantiate(smoke, transform.position, Quaternion.identity);

	}
	
	void Update () {
        transform.Translate(0, speed, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 10, LayerMask.NameToLayer("Player 1"));
        if (hit.collider != null) {
            if (hit.transform.tag == "Tank") {
                hit.transform.GetComponent<ColliderPart>().Hit();
                DestroySelf();
            }
        }
        Debug.DrawRay(transform.position, transform.up * 10, Color.red);
	}
    void DestroySelf() {
        Destroy(gameObject);
    }
}
