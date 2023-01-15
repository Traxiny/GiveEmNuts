using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameOverScript GameOverScreen;
    [SerializeField]
    private GameObject scoreText;
    private TMP_Text scrText;

    public int Score = 0;
    public bool isDay = true;
    // Start is called before the first frame update
    void Start()
    {
        scrText = scoreText.GetComponent<TMP_Text>();
        scrText.text = "Score: " + Score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        GameOverScreen.Setup(Score);
    }
    public void AddScore()
    {
        Score += 50;
        scrText.text = "Score: " + Score;
    }

}
