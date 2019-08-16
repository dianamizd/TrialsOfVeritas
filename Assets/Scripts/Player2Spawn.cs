using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawn : MonoBehaviour
{
    private int characterSelectP2;

    [SerializeField] private GameObject P2Archer;
    [SerializeField] private GameObject P2Gladiator;
    [SerializeField] private GameObject P2Warlock;

    [SerializeField] private Transform player2Spawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelect");

        characterSelectP2 = characterSelect.GetComponent<CharacterSelect>().playerCharacter1;

        if (characterSelectP2 == 1)
        {
            P2Archer.SetActive(true);
            P2Gladiator.SetActive(false);
            P2Warlock.SetActive(false);
        }

        if (characterSelectP2 == 2)
        {
            P2Archer.SetActive(false);
            P2Gladiator.SetActive(true);
            P2Warlock.SetActive(false);
        }

        if (characterSelectP2 == 3)
        {
            P2Archer.SetActive(false);
            P2Gladiator.SetActive(false);
            P2Warlock.SetActive(true);
        }
    }
}
