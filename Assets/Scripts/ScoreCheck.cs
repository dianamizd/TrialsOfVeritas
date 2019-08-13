using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck : MonoBehaviour
{
    public Text WinText;

    public Button returnToMenu;

    private bool returnToMenuActive = false;

    public float countdownTimer;

    public Text countdownTimerText;

    private bool pauseActive;

    [SerializeField] private Player1Input playerOneScript;

    [SerializeField] private Player2Input playerTwoScript;

    void Start()
    {
        pauseActive = false;

        playerOneScript.enabled = false;

        playerTwoScript.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        if(!pauseActive)
        {
            Time.timeScale = 1f;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseActive = true;
            }
        }
       
        if(pauseActive)
        {
            Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseActive = false;
            }
        }
       

        //when player 1 wins
        if (playerOneScript.currentRoundCount == playerOneScript.maxRoundCount)
        {
            WinText.text = "PLAYER 1 WIN";

            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            if(!returnToMenuActive)
            {
                returnToMenu.enabled = true;
            }
           
        }

        //when player 2 wins
        if (playerTwoScript.currentRoundCount == playerTwoScript.maxRoundCount)
        {
            WinText.text = "PLAYER 2 WIN";

            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            if(!returnToMenuActive)
            {
                returnToMenu.enabled = true;
            }
           
        }
    }

    //method for countdown timer
    public void CountdownTimer()
    {
        if (countdownTimer > 1)
        {
            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            countdownTimer -= 1 * Time.deltaTime;

            countdownTimerText.text = "" + (int)(countdownTimer % 60);
        }
        else
        {
            countdownTimerText.text = "";

            playerOneScript.enabled = true;

            playerTwoScript.enabled = true;
        }
    }
}
