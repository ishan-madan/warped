using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTriggers : MonoBehaviour
{

    public Elevator elevator;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            RunTriggers();
        }
    }

    void RunTriggers() {
        if (gameObject.tag == "OpenDoorTrigger"){
            elevator.doorOpened = true;
        }
        if (gameObject.tag == "CloseDoorTrigger"){
            elevator.doorOpened = false;
            elevator.upPossible = true;
        }
        if (gameObject.tag == "CloseDoorTrigger2"){
            elevator.doorOpened = false;
            elevator.upPossible = false;
        }

        gameObject.SetActive(false);
    }
}
