using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleLevel2 : MonoBehaviour
{
    public PauseMenuLevel2 pauseScript;
    public LaserKillScript laserKillScript;

    
    void Update()
    {
        if (pauseScript.isPaused || pauseScript.controls){
            laserKillScript.setCamConstraints();
            AudioListener.pause = true;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else {
            laserKillScript.removeCamConstraints();
            AudioListener.pause = false;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
