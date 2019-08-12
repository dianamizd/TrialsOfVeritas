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

    [SerializeField] private Player1Input playerOneScript;

    [SerializeField] private Player2Input playerTwoScript;

    void Start()
    {
        playerOneScript.enabled = false;

        playerTwoScript.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

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

    public void CountdownTimer()
    {
        if (countdownTimer >= 1)
        {
            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            countdownTimer -= 1 * Time.deltaTime;

            countdownTimerText.text = "" + (int)(countdownTimer % 60);
        }
        else
        {
            playerOneScript.enabled = true;

            playerTwoScript.enabled = true;

            countdownTimerText.text = "";
        }
    }
}
