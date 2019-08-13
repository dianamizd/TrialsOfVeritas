using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawn : MonoBehaviour
{
    private string characterSelectP2;

    [SerializeField] private GameObject player2Archer;
    [SerializeField] private GameObject player2Gladiator;
    [SerializeField] private GameObject player2Warlock;

    [SerializeField] private Transform player2Spawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelect");

        characterSelectP2 = characterSelect.GetComponent<CharacterSelect>().playerCharacter2;

        if (characterSelectP2 == "P2Archer")
        {
            Instantiate(player2Archer, player2Spawn.position, player2Spawn.rotation);
        }

        if (characterSelectP2 == "P2Gladiator")
        {
            Instantiate(player2Gladiator, player2Spawn.position, player2Spawn.rotation);
        }

        if (characterSelectP2 == "P2Warlock")
        {
            Instantiate(player2Warlock, player2Spawn.position, player2Spawn.rotation);
        }
    }
}
