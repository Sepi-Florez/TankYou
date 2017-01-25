using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {
    public int damageValue;
    public int part;
    void OnCollisionEnter2D(Collision2D bullet) {
        if(bullet.transform.tag == "Bullet") {
            Destroy(bullet.gameObject);
            transform.parent.GetComponent<Tank>().Hit(damageValue, part);

        }
    }
}
