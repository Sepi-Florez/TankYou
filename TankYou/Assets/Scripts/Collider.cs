using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {
    public int damageValue;
    void OnCollisionEnter2D(Collision2D bullet) {
        if(bullet.transform.tag == "Bullet") {
            transform.parent.GetComponent<Tank>().Hit(damageValue);
            Destroy(bullet.gameObject);
        }
    }
}
