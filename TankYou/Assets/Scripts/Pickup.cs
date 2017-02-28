using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int pickUpType = 3;

	void PickUpManager() {

        switch (pickUpType) {
            case 3:
                print("Case3 works");
                break;
            case 2:
                print("Case2 works");
                break;
            case 1:
                print("Case1 works");
                break;
            default:
                print("Default works");
                break;
        }
    }
}
