﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {
    public GameObject[] ammoObject;
    public GameObject[] healthObject;
    public int[] score;
    public bool realod = false;

    void Awake() {

    }
    public void ammoUpdate(int player, int count) {
        print(count);
        if(count == -1) {
            int a = 0;
            foreach (Transform ammo in ammoObject[player].transform) {
                ammoObject[player].transform.GetChild(a).GetComponent<Animator>().SetTrigger("Trigger");
                a++;
            }
        }
        else {
            ammoObject[player].transform.GetChild(count).GetComponent<Animator>().SetTrigger("Trigger");
        }

    }
}
