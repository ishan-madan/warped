using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPicture : MonoBehaviour
{
    Color color;
    public Renderer renderer;
    float i = 0;

    void Start(){
        renderer.material.color = color;
    }

    void Update(){
        i += 1 / 360f;
        if (i >= 1){
            i = 0f;
        }
        color = Color.HSVToRGB(i, 1, 1);;
        renderer.material.EnableKeyword("_EMISSION");
        renderer.material.SetColor("_EmissionColor", color);
    }
}
