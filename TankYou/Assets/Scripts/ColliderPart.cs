using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPart : MonoBehaviour {
    public int damageValue;
    public int part;
    /*void OnTriggerEnter2D(Collider2D bullet) {
        if (bullet.transform.tag == "Bullet" && bullet.GetComponent<Bullet>().origin != transform.root.GetComponent<Tank>().playerNumber) {
            Destroy(bullet.gameObject);
            transform.parent.GetComponent<Tank>().Hit(damageValue, part);

        }
        else {
        }
    }*/
    public void Hit() {
        transform.parent.GetComponent<Tank>().Hit(damageValue, part);
    }
}
