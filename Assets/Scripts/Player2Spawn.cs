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
            Instantiate(P2Archer, player2Spawn.position, player2Spawn.rotation);
        }

        if (characterSelectP2 == 2)
        {
            Instantiate(P2Gladiator, player2Spawn.position, player2Spawn.rotation);
        }

        if (characterSelectP2 == 3)
        {
            Instantiate(P2Warlock, player2Spawn.position, player2Spawn.rotation);
        }
    }
}
