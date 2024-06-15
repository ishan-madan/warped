using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public GameObject[] Triggers;
    [SerializeField] private GameObject[] InstructionMenuUI;
    public bool prompting = false;
    bool skipping = false;
    public int counter = -1;
    PauseMenu pauseMenu;
    
    // hides all pause/control menu panels
    private void Awake(){
        for (int i = 0; i < InstructionMenuUI.Length - 1; i+= 1){
            InstructionMenuUI[i].SetActive(false);
        }
    }

    private void Start() {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // activates and deactivates menu and removes triggers if needed
    private void Update() {
        if (prompting){
            ActivateMenu();
        }
        else if (!pauseMenu.isPaused) {
            DeactivateMenu();
        }

        if (Triggers[Random.Range(0, Triggers.Length - 1)].transform.position.y <= 950 && skipping){
            Debug.Log("removing triggers");
            triggerRemover();
        }


    }

    // activates controls menu
    void ActivateMenu() {
        Cursor.lockState = CursorLockMode.None;
        InstructionMenuUI[counter].SetActive(true);
        InstructionMenuUI[counter].transform.SetAsLastSibling();
    }

    //deactivates controls menu
    void DeactivateMenu() {
        if (counter >= 0){
            Cursor.lockState = CursorLockMode.Locked;
            InstructionMenuUI[counter].SetActive(false);
            InstructionMenuUI[counter].transform.SetAsFirstSibling();
        }
    }

    // skips tutorial
    public void skipButton(){
        prompting = false;
        skipping = true;
        triggerRemover();
    }

    // continues tutorial
    public void continueButton(){
        prompting = false;
    }

    // removes triggers
    public void triggerRemover() {
        for (int i = 0; i < Triggers.Length; i += 1){
            Triggers[i].transform.position = new Vector3(Triggers[i].transform.position.x, 1000, Triggers[i].transform.position.z);
        }
    }
}
