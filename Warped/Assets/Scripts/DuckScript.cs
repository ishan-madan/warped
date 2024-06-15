using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{

    float scaleValue = 1;
    bool sizeChanging = false;



    void Start()
    {
       transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
    }


    void Update()
    {
        if (Input.GetKeyDown("c") && !sizeChanging){
            StartCoroutine(Shrink());
        }
        
        if (Input.GetKeyUp("c") && !sizeChanging){
            StartCoroutine(Enlarge());
        }
    }



    IEnumerator Shrink() {
        sizeChanging = true;
        for (float i = scaleValue; i > 0.3; i -= 0.01f){
            transform.localScale = new Vector3(i, i, i);
            scaleValue = i;
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("shrink");
        sizeChanging = false;
    }

    IEnumerator Enlarge() {
        sizeChanging = true;
        for (float i = scaleValue; i < 1; i -= 0.01f){
            transform.localScale = new Vector3(i, i, i);
            scaleValue = i;
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("enlarge");
        sizeChanging = false;
    }
}
