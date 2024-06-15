using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{

    public AudioSource musicFile;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // checking whether or not the game music should be playing or the start menu music should be playing
    void Update(){
        // checking if active scene is start screen
        if (SceneManager.GetActiveScene().name == "StartScreen"){
            musicFile.Pause();
        }
        else {
            if (!musicFile.isPlaying){
                musicFile.Play();
            }
        }
    }

}
