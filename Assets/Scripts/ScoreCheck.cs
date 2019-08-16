using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck : MonoBehaviour
{
    public Text WinText;

    public Text pausedText;

    public GameObject returnToMenuButton;

    public static bool returnToMenuActive = false;

    public float countdownTimer;

    public Text countdownTimerText;

    public static bool pauseActive = false;

    [SerializeField] private Player1Input playerOneScript;
    [SerializeField] private Player1Input playerOneScriptArcher;
    [SerializeField] private Player1Input playerOneScriptGladiator;
    [SerializeField] private Player1Input playerOneScriptWarlock;

    [SerializeField] private Player2Input playerTwoScript;
    [SerializeField] private Player2Input playerTwoScriptArcher;
    [SerializeField] private Player2Input playerTwoScriptGladiator;
    [SerializeField] private Player2Input playerTwoScriptWarlock;


    void Start()
    {
        playerOneScript.enabled = false;

        playerTwoScript.enabled = false;

        returnToMenuButton.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        CountdownTimer();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseActive)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

        if (playerOneScript.currentRoundCount == playerOneScript.maxRoundCount)
        {
            WinText.text = "PLAYER 1 WIN";

            playerOneScript.enabled = false;
            playerOneScriptArcher.enabled = false;
            playerOneScriptGladiator.enabled = false;
            playerOneScriptWarlock.enabled = false;

            playerTwoScript.enabled = false;
            playerTwoScriptArcher.enabled = false;
            playerTwoScriptGladiator.enabled = false;
            playerTwoScriptWarlock.enabled = false;

            returnToMenuButton.SetActive(true);
           
        }

        if (playerTwoScript.currentRoundCount == playerTwoScript.maxRoundCount)
        {
            WinText.text = "PLAYER 2 WIN";

            playerOneScript.enabled = false;
            playerOneScriptArcher.enabled = false;
            playerOneScriptGladiator.enabled = false;
            playerOneScriptWarlock.enabled = false;

            playerTwoScript.enabled = false;
            playerTwoScriptArcher.enabled = false;
            playerTwoScriptGladiator.enabled = false;
            playerTwoScriptWarlock.enabled = false;

            returnToMenuButton.SetActive(true);

        }
    }

    public void CountdownTimer()
    {
        if (countdownTimer >= 1)
        {
            playerOneScript.enabled = false;
            playerOneScriptArcher.enabled = false;
            playerOneScriptGladiator.enabled = false;
            playerOneScriptWarlock.enabled = false;

            playerTwoScript.enabled = false;
            playerTwoScriptArcher.enabled = false;
            playerTwoScriptGladiator.enabled = false;
            playerTwoScriptWarlock.enabled = false;

            countdownTimer -= 1 * Time.deltaTime;

            countdownTimerText.text = "" + (int)(countdownTimer % 60);
        }
        else
        {
            playerOneScript.enabled = true;
            playerOneScriptArcher.enabled = true;
            playerOneScriptGladiator.enabled = true;
            playerOneScriptWarlock.enabled = true;

            playerTwoScript.enabled = true;
            playerTwoScriptArcher.enabled = true;
            playerTwoScriptGladiator.enabled = true;
            playerTwoScriptWarlock.enabled = true;

            countdownTimerText.text = "";
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        returnToMenuButton.SetActive(false);
        pauseActive = false;
        pausedText.text = "";
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        returnToMenuButton.SetActive(true);
        pauseActive = true;
        pausedText.text = "Paused Press Esc To Resume";
        Debug.Log("game is paused");
    }

    
}
