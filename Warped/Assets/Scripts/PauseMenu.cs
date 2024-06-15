using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject ControlsMenuUI;
    public bool isPaused = false;
    public bool controls = false;
    bool goingHome = false;
    public ManageScene SceneScript;
    public TriggerController triggerScript;
    public vThirdPersonCamera camScript;
    public Rigidbody playerRB;
    public Rigidbody camRB;
    SensitivitySaver senseSaver;
    SliderControl sliderCont;
    
    
    private void Awake(){
        sliderCont = FindObjectOfType<SliderControl>();
        senseSaver = FindObjectOfType<SensitivitySaver>();
        PauseMenuUI.SetActive(false);
        ControlsMenuUI.SetActive(false);
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            isPaused = true;
        }

        if (isPaused && !triggerScript.prompting){
            ActivateMenu();
        }
        else {
            DeactivateMenu();
        }

        if (!goingHome){
            camScript.xMouseSensitivity = sliderCont.round(sliderCont.slider.value);
            camScript.yMouseSensitivity = sliderCont.round(sliderCont.slider.value);
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
        SensitivitySaver.sensitivity = sliderCont.round(sliderCont.slider.value);
        isPaused = false;
        controls = false;
        ControlsMenuUI.SetActive(false);
    }

    public void controlsButton(){
        SensitivitySaver.sensitivity = sliderCont.round(sliderCont.slider.value);
        isPaused = false;
        controls = true;
        ControlsMenuUI.SetActive(true);
    }

    public void homeButton(){
        goingHome = true;
        SensitivitySaver.sensitivity = sliderCont.round(sliderCont.slider.value);
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
