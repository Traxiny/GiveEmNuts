using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    private TMP_Text text;
    public void Setup(int score)
    {
        text = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        text.text = "Score: " + score;
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
