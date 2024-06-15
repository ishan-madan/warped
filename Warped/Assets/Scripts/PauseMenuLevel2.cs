using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuLevel2 : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject ControlsMenuUI;
    public bool isPaused = false;
    public bool controls = false;
    public ManageScene SceneScript;
    public vThirdPersonCamera camScript;
    public Rigidbody playerRB;
    public Rigidbody camRB;
    SensitivitySaver senseSaver;
    SliderControl sliderControl;
    bool goingHome = false;
    
    
    private void Awake(){
        senseSaver = FindObjectOfType<SensitivitySaver>();
        sliderControl = FindObjectOfType<SliderControl>();
        PauseMenuUI.SetActive(false);
        ControlsMenuUI.SetActive(false);
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            isPaused = true;
        }

        if (isPaused){
            ActivateMenu();
        }
        else {
            DeactivateMenu();
        }

        if (!goingHome){
            camScript.xMouseSensitivity = sliderControl.round(sliderControl.slider.value);
            camScript.yMouseSensitivity = sliderControl.round(sliderControl.slider.value);
        }

    }


    void ActivateMenu() {
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        PauseMenuUI.transform.SetAsLastSibling();
    }


    void DeactivateMenu() {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        PauseMenuUI.transform.SetAsFirstSibling();
    }


    public void resumeButton(){
        SensitivitySaver.sensitivity = sliderControl.round(sliderControl.slider.value);
        isPaused = false;
        controls = false;
        ControlsMenuUI.SetActive(false);
    }

    public void controlsButton(){
        SensitivitySaver.sensitivity = sliderControl.round(sliderControl.slider.value);
        isPaused = false;
        controls = true;
        ControlsMenuUI.SetActive(true);
    }

    public void homeButton(){
        goingHome = true;
        SensitivitySaver.sensitivity = sliderControl.round(sliderControl.slider.value);
        isPaused = false;
        controls = false;
        playerRB.constraints = RigidbodyConstraints.FreezePosition;
        camScript.xMouseSensitivity = 0f;
        camScript.yMouseSensitivity = 0f;
        StartCoroutine(SceneScript.DimScreen());
        Invoke("sendHome", 2f);
        ControlsMenuUI.SetActive(false);
    }

    void sendHome() {
        goingHome = false;
        SceneManager.LoadScene("StartScreen");
    }





}
