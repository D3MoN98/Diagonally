using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameObject highetScoreMark;
    private bool reachedBest = false;

    private void Start()
    {
        if (PlayerPrefs.GetInt("highestScore", 0) != 0)
        {
            Vector3 markPos = new Vector3(highetScoreMark.transform.position.x,
                highetScoreMark.transform.position.y,
                (float)PlayerPrefs.GetInt("highestScore"));
            highetScoreMark.transform.position = markPos;
            highetScoreMark.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string text = "Best ";
        if ((int)player.position.z > PlayerPrefs.GetInt("highestScore", 0))
        {
            PlayerPrefs.SetInt("highestScore", (int) player.position.z);
            reachedBest = true;
        }
       
        scoreText.text = (reachedBest ? text : "") + (int)player.position.z;


    }
}
