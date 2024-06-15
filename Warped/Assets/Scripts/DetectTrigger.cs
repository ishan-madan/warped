using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
    public TriggerController triggerScript;
    public string directionOfEnaction;

    void OnTriggerEnter() {
        // if statement used to only use the onTriggerEnter function if tht is the type of activation is want (in contrast to onTriggerExit)
        if (directionOfEnaction.ToLower() == "enter"){
            triggerLogic();
        }
    }

    void OnTriggerExit(){
        // if statement used to only use the onTriggerExit function if tht is the type of activation is want (in contrast to onTriggerEnter)
        if (directionOfEnaction.ToLower() == "exit"){
            triggerLogic();
        }
    }

    void OnCollisionEnter(){
        // if statement used to only use the onTriggerExit function if tht is the type of activation is want (in contrast to onTriggerEnter)
        if (directionOfEnaction.ToLower() == "collision"){
            triggerLogic();
        }
    }
    
    // adds 1 to the counter to activate right menu and starts triggerAction function at the correct tie, depending on which menu
    void triggerLogic() {
        triggerScript.counter += 1;

        if (triggerScript.counter == 0){
            // 1.5f delay to account for the fading out panel
            Invoke("triggerAction", 1.5f);
        }
        else {
            triggerAction();
        }
    }

    // sets prompting to true and moves the engaged trigger out of the way
    public void triggerAction(){
        triggerScript.Triggers[triggerScript.counter].transform.position = new Vector3(triggerScript.Triggers[triggerScript.counter].transform.position.x, 100000, triggerScript.Triggers[triggerScript.counter].transform.position.z);
        triggerScript.prompting = true;
    }
}
