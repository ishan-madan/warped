using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    float transparency = 1;
    public Image panel;
    public RectTransform PanelGO;
    public LaserKillScript laserKillScript;

    void Start()
    {
        // setting cursor to invisible if the game has started

        if (SceneManager.GetActiveScene().name != "StartScreen"){
            Cursor.visible = false;
        }
        else {
            Cursor.visible = true;
        }
        
        if (laserKillScript != null){
            laserKillScript.removeCamConstraints();             // removes cam constraints if there are any
        }

        panel.color = new Color(0, 0, 0, 1);                    // initializing the color of the panel to be black
        Invoke("FadeInPanel", 1f);                              // 1f delay to allow some time between scene switch (makes it look nice)
    }

    //logic to fade panel in
    public void FadeInPanel()
    {
        PanelGO.transform.SetAsLastSibling();                   // sets panel on top of canvas
        StartCoroutine(BrightenScreen());                       // brightens the sceen
        
    }

    IEnumerator BrightenScreen()
    {
        // for loop to change the transparency of the panel
        for (float i = 1; i >= 0; i -= 0.01f)
        {
            transparency = i;                                   // sets transparency to the i value
            panel.color = new Color(0, 0, 0, transparency);     // resets panel color w/ transparency
            yield return new WaitForSeconds(0.01f);             // 0.01 second delay between call of the loop
            PanelGO.transform.SetAsLastSibling();               // puts panel on the front of the canvas
        }
        PanelGO.transform.SetAsFirstSibling();                  // puts panel at the back of the canvas after the foor loop is finished

    }
}