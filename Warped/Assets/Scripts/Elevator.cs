using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject elevatorBody;
    public Rigidbody elevatorBodyRB;
    public GameObject leftDoor;
    public GameObject rightDoor;
    [HideInInspector] public bool doorOpened = false;
    Vector3 leftDoorClosed;
    Vector3 rightDoorClosed;
    Vector3 leftDoorOpened;
    Vector3 rightDoorOpened;
    [Range(0, 10)]
    public float doorSpeed;
    float doorStep;
    Vector3 elevatorTarget;
    public float heightOfElevator;
    bool goUp = false;
    [Range(0, 10)]
    public float elevatorSpeed;
    float elevatorStep;
    // public Rigidbody player;
    [HideInInspector] public bool upPossible = false;



    void Start() {
        leftDoorClosed = leftDoor.transform.localPosition;
        rightDoorClosed = rightDoor.transform.localPosition;
        leftDoorOpened = new Vector3 (leftDoorClosed.x - 2.1f, leftDoorClosed.y, leftDoorClosed.z);
        rightDoorOpened = new Vector3 (rightDoorClosed.x + 2.1f, rightDoorClosed.y, rightDoorClosed.z);
        elevatorTarget = elevatorBody.transform.localPosition + new Vector3(0, heightOfElevator, 0);
    }

    void FixedUpdate() {
        doorStep = doorSpeed * Time.deltaTime;
        elevatorStep = elevatorSpeed * Time.deltaTime;


        if (doorOpened){
            OpenDoors();
        }
        else if (!doorOpened){
            CloseDoors();
        }

        if (goUp){
            GoUp();
        }
        
    }

    void OpenDoors() {
        if (Vector3.Distance(leftDoorOpened, leftDoor.transform.localPosition) > 0.001f){
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorOpened, doorStep);
        }
        if (Vector3.Distance(rightDoorOpened, rightDoor.transform.localPosition) > 0.001f){
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorOpened, doorStep);
        }
    }

    void CloseDoors() {
        if (Vector3.Distance(leftDoorClosed, leftDoor.transform.localPosition) > 0.001f){
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorClosed, doorStep);
        }
        if (Vector3.Distance(rightDoorClosed, rightDoor.transform.localPosition) > 0.001f){
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorClosed, doorStep);
        }
        else {
            if (upPossible){
                goUp = true;
            }
        }
    }

    void GoUp() {
        if (Vector3.Distance(elevatorTarget, elevatorBody.transform.localPosition) > 0.001f){
            elevatorBody.transform.localPosition = Vector3.MoveTowards(elevatorBody.transform.localPosition, elevatorTarget, elevatorStep);
            // player.velocity = elevatorBodyRB.velocity + new Vector3(0, 0.1f, 0);
        }
        else {
            if (upPossible){
                doorOpened = true;
            }
        }
    }

}
