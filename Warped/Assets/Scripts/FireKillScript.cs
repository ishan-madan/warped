using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireKillScript : MonoBehaviour
{

    public Rigidbody playerRB;
    public Rigidbody camRB;
    public ManageScene SceneScript;
    public vThirdPersonCamera camScript;
    public Image panel;
    public RectTransform PanelGO;
    float transparency = 0;

    void OnTriggerEnter(Collider col){
        if (col.name == "ThirdPersonController"){
            PanelGO.transform.SetAsLastSibling();                       // panel set on top of canvas
            playerRB.constraints = RigidbodyConstraints.FreezePosition; // freezes player in air
            setCamConstraints();                                        // sets camera constraints
            StartCoroutine(SceneScript.DimScreen());                    // dims screen for level reset
            Invoke("resetLevel", 2f);                                   // resets lavel after 2f delay to allow for screen dimming
        }
    }

    // made into a function to be accessed by other script (TriggerController)
    public void setCamConstraints(){
        camScript.xMouseSensitivity = 0f;                               // cam sensitivity on x axis set to 0
        camScript.yMouseSensitivity = 0f;                               // cam sensitivity on y axis set to 0
    }

    // function to be used in other script (TriggerController) so that i dont have to initialize all of the above variable again
    public void removeCamConstraints(){
        if (camScript.xMouseSensitivity != 10f && camScript.yMouseSensitivity != 10f){  // only runs if needed
            camScript.xMouseSensitivity = 10f;                                            // cam sensitivity on x axis set back to default
            camScript.yMouseSensitivity = 10f;                                            // cam sensitivity on y axis set back to default
        }
    }

    void resetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // resets level on death
    }

}
