using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {
    public GameObject[] ammoObject;
    public GameObject[] healthObject;
    public int[] score;
    public bool realod = false;

    void Awake() {

    }
    public void ammoUpdate(int player, int count) {
        if(count == -1) {
            int a = 0;
            foreach (Transform ammo in ammoObject[player - 1].transform) {
                ammoObject[player - 1].transform.GetChild(a).GetComponent<Animator>().SetTrigger("Trigger");
                a++;
            }
        }
        else {
            ammoObject[player - 1].transform.GetChild(count).GetComponent<Animator>().SetTrigger("Trigger");
        }

    }
    public void healthUpdate(int player, int health, int part) {
        float fillValue = health;
        fillValue = fillValue / 100;
        healthObject[player - 1].transform.GetChild(part + 3).GetComponent<Image>().fillAmount = fillValue; 
    }   
}
