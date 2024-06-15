using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [Range(0, 30)]
    public int rotateSpeed;

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0, Space.Self);
    }
}
