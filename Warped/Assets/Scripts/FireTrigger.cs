using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    public GameObject[] particleSystemsToBeActivated;
    // public GameObject[] lightsToBeActivated;
    public GameObject trigger;

    void OnTriggerEnter(Collider col){
        if (col.tag == "Player"){
            StartCoroutine(PlayParticleEffects());
        }
    }


    IEnumerator PlayParticleEffects(){
        for (int i = 0; i < particleSystemsToBeActivated.Length; i += 1){
            particleSystemsToBeActivated[i].SetActive(true);
            // lightsToBeActivated[i].SetActive(true);
            yield return new WaitForSeconds(0.0001f);
        }
        trigger.SetActive(false);
    }
}
