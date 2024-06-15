using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    float transparency = 0;
    public Image panel;
    public RectTransform PanelGO;
    public bool colliderCheck;
    public LaserKillScript laserKillScript;
    public Rigidbody playerRB;
    public vThirdPersonCamera camScript;

    public void nextLevel()
    {
        PanelGO.transform.SetAsLastSibling();
        StartCoroutine(DimScreen());
        Invoke("nextLevelLogic", 2f);
    }

    public void Home()
    {
        PanelGO.transform.SetAsLastSibling();
        StartCoroutine(DimScreen());
        Invoke("HomeLogic", 2f);
    }

    public IEnumerator DimScreen()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            transparency = i;
            panel.color = new Color(0, 0, 0, transparency);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void nextLevelLogic()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void HomeLogic()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider col){
        if (colliderCheck){
            if (col.tag == "Player"){
                if (playerRB != null && camScript != null){
                    playerRB.constraints = RigidbodyConstraints.FreezePosition;
                camScript.xMouseSensitivity = 0f;                               // cam sensitivity on x axis set to 0
                camScript.yMouseSensitivity = 0f;                               // cam sensitivity on y axis set to 0
                }
                nextLevel();
            }
        }
    }
}
