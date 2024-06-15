// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WORKPLACE : MonoBehaviour
// {
    

//     // moves laser along x axis
//     void MoveOnXAxis(){

//         //logic to determine which direction to move the laser in 
//         if (transform.localPosition.x < upperBound && transform.localPosition.x > lowerBound && lastSideBottom){
//             movingUp = true;
//         }
//         else if (transform.localPosition.x < upperBound && transform.localPosition.x > lowerBound && !lastSideBottom){
//             movingUp = false;
//         }
//         else if (transform.localPosition.x <= lowerBound){
//             movingUp = true;
//             lastSideBottom = true;
//         }
//         else if (transform.localPosition.x >= upperBound){
//             movingUp = false;
//             lastSideBottom = false;
//         }
//         else {
//             movingUp = true;
//         }


//         // changing localPosition of the laser
//         if (movingUp){
//             transform.localPosition = new Vector3 (transform.localPosition.x + laserSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
//         }
//         else {
//             transform.localPosition = new Vector3 (transform.localPosition.x - laserSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
//         }
//     }

//     // moves laser along y axis
//     void MoveOnYAxis(){

//         //logic to determine which direction to move the laser in 
//         if (transform.localPosition.y < upperBound && transform.localPosition.y > lowerBound && lastSideBottom){
//             movingUp = true;
//         }
//         else if (transform.localPosition.y < upperBound && transform.localPosition.y > lowerBound && !lastSideBottom){
//             movingUp = false;
//         }
//         else if (transform.localPosition.y <= lowerBound){
//             movingUp = true;
//             lastSideBottom = true;
//         }
//         else if (transform.localPosition.y >= upperBound){
//             movingUp = false;
//             lastSideBottom = false;
//         }
//         else {
//             movingUp = true;
//         }

//         // changing localPosition of the laser
//         if (movingUp){
//             transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + laserSpeed * Time.deltaTime, transform.localPosition.z);
//         }
//         else {
//             transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - laserSpeed * Time.deltaTime, transform.localPosition.z);
//         }
//     }

//         // moves laser along z axis
//     void MoveOnZAxis(){

//         //logic to determine which direction to move the laser in 
//         if (transform.localPosition.z < upperBound && transform.localPosition.z > lowerBound && lastSideBottom){
//             movingUp = true;
//         }
//         else if (transform.localPosition.z < upperBound && transform.localPosition.z > lowerBound && !lastSideBottom){
//             movingUp = false;
//         }
//         else if (transform.localPosition.z <= lowerBound){
//             movingUp = true;
//             lastSideBottom = true;
//         }
//         else if (transform.localPosition.z >= upperBound){
//             movingUp = false;
//             lastSideBottom = false;
            
//         }
//         else {
//             movingUp = true;
//         }


//         // changing localPosition of the laser
//         if (movingUp){
//             transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + laserSpeed * Time.deltaTime);
//         }
//         else {
//             transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - laserSpeed * Time.deltaTime);
//         }
//     }






// }
