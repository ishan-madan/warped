using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public PauseMenu pauseScript;
    public TriggerController triggerScript;
    public LaserKillScript laserKillScript;

    
    void Update()
    {
        if (pauseScript.isPaused || pauseScript.controls || triggerScript.prompting){
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
