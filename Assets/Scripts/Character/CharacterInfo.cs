using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    // Can do public and set in Unity, or private and find in Start()
    public GameObject playerScoreObject;
    public GameObject gameOverText;
    public Text playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        playerScoreText = playerScoreObject.GetComponent<Text>();
        playerScoreText.text = "Score: 0";
    }

    public void UpdateScoreText(int score) {
        playerScoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.SetActive(true);
    }
}
