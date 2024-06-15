using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class LaserMoveScript : MonoBehaviour
{
    public enum Axis{ moveToPoints, xRotate, yRotate, zRotate, dontMove}    
    public Axis axisOfMovement;         // which axis to move or rotate laser along
    [Range(0.0f, 10.0f)]                // laser speed sliding bar range 
    public float laserSpeed;            // speed of the laser
    [Range(0, 360)]                     // rotate sliding bar range
    public int rotateSpeed;             // speed of rotation
    public Vector3 offset;              // if you copy/paste, you can put in offset
    public Vector3[] points;            // sets corners for the boxes
    public int cornerNumber = 1;               // sets the correct corner to go towards
    public float marginOfError = 0.3f;  // sets margin of error for the distance of the box movement laser to its point
    [Range(0, 100)]
    public float speedMultiplier = 1;
    public bool reverse = false;

    void FixedUpdate() {
        if (axisOfMovement != Axis.dontMove){
            if (axisOfMovement == Axis.moveToPoints){
                moveToPoints();
            }
            else if (axisOfMovement == Axis.xRotate){
                RotateOnXAxis();
            }
            else if (axisOfMovement == Axis.yRotate){
                RotateOnYAxis();
            }
           else {
               RotateOnZAxis();
           }
        }
    }


    // rotates in x direction
    void RotateOnXAxis() {
        // rotates laser
        transform.Rotate(rotateSpeed * Time.deltaTime, 0f, 0f, Space.Self);
    }

    // rotates in y direction
    void RotateOnYAxis() {
        // rotates laser
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
    }

    // rotates in z direction
    void RotateOnZAxis() {
        // rotates laser
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime, Space.Self);
    }

    // moves laser to given points
    void moveToPoints(){
        if (Vector3.Distance(points[cornerNumber - 1] + offset, transform.position) < marginOfError){
            if (!reverse){
                cornerNumber += 1;
            }
            else if (reverse){
                cornerNumber -= 1;
            }
            
            if (cornerNumber >= points.Length + 1 && !reverse){
                cornerNumber = 1;
            }
            else if (cornerNumber <= 0 && reverse){
                cornerNumber = points.Length;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[cornerNumber - 1] + offset, laserSpeed * speedMultiplier * Time.deltaTime);
    }

}

