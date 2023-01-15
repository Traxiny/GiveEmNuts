using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainCam;
    private AudioSource mainAudioSource;
    private float defaultVolume = 0.66f;
    float transitionTime = 2.0f;
    private void Start()
    {
        mainCam = GameObject.Find("MainCamera");
        mainAudioSource = mainCam.GetComponent<AudioSource>();
    }

    IEnumerator FadeOut()
    {
        float percentage = 0;
        Debug.Log(mainAudioSource.volume);
        while (mainAudioSource.volume > 0)
        {
            mainAudioSource.volume = Mathf.Lerp(defaultVolume,0, percentage);
            percentage += Time.deltaTime / transitionTime;
            yield return null;
        }
        mainAudioSource.volume-=0.01f;
        Debug.Log(mainAudioSource.volume);
        yield return null;
    }

    public void PlayGame()
    {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
