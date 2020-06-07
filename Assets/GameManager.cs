using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float restartDelay = 2f;
    public TextMeshProUGUI highetScoreText;

    public GameObject quitPopUp;

    private void Start()
    {
        if (highetScoreText)
        {
            highetScoreText.text = "Best " + PlayerPrefs.GetInt("highestScore", 0).ToString();
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Quit();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void GameOver()
    {
        if (!isGameOver)
        {
            Debug.Log("Game Over");
            isGameOver = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitQuitPopUp()
    {
        quitPopUp.SetActive(false);
    }


    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
