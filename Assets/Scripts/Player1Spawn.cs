using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawn : MonoBehaviour
{
    private int characterSelectP1;

    [SerializeField] private GameObject P1Archer;
    [SerializeField] private GameObject P1Gladiator;
    [SerializeField] private GameObject P1Warlock;

    [SerializeField] private Transform player1Spawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelect");

        characterSelectP1 = characterSelect.GetComponent<CharacterSelect>().playerCharacter1;

        if (characterSelectP1 == 1)
        {
            P1Archer.SetActive(true);
            P1Gladiator.SetActive(false);
            P1Warlock.SetActive(false);
        }

        if (characterSelectP1 == 2)
        {
            P1Archer.SetActive(false);
            P1Gladiator.SetActive(true);
            P1Warlock.SetActive(false);
        }

        if (characterSelectP1 == 3)
        {
            P1Archer.SetActive(false);
            P1Gladiator.SetActive(false);
            P1Warlock.SetActive(true);
        }
    }

    
}
