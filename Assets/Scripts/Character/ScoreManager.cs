using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public int playerScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        characterInfo = GetComponent<CharacterInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        playerScore += 1;
        characterInfo.UpdateScoreText(playerScore);
    }
}
