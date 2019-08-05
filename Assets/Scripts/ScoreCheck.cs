﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck : MonoBehaviour
{
    public Text WinText;

    public Button returnToMenu;

    [SerializeField] private Player1Input playerOneScript;

    [SerializeField] private Player2Input playerTwoScript;

    // Update is called once per frame
    void Update()
    {
        if(playerOneScript.currentRoundCount == playerOneScript.maxRoundCount)
        {
            WinText.text = "PLAYER 1 WIN";

            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            if(!returnToMenu)
            {
                returnToMenu.enabled = true;
            }
           
        }

        if (playerTwoScript.currentRoundCount == playerTwoScript.maxRoundCount)
        {
            WinText.text = "PLAYER 2 WIN";

            playerOneScript.enabled = false;

            playerTwoScript.enabled = false;

            if(!returnToMenu)
            {
                returnToMenu.enabled = true;
            }
           
        }
    }
}
