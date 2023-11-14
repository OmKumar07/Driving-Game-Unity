using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private AudioLowPassFilter Filter;
    private AudioSource Audio;
    private void Awake()
    {
        Filter = transform.GetComponent<AudioLowPassFilter>();
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            DontDestroyOnLoad(transform.gameObject);
            
        }

        GameObject[] MusicObj = GameObject.FindGameObjectsWithTag("Music");
        if (MusicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        Audio = transform.GetComponent<AudioSource>();
        

    }
    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int SceneNumber = currentScene.buildIndex;
        if (SceneNumber == 1)
        {
            Filter.cutoffFrequency = 1000;
        }
        else
            Filter.cutoffFrequency = 22000;
        if(SceneNumber == 2)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Audio.mute = false;
        }else
            Audio.mute = true;
    }
}
