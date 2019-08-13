using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawn : MonoBehaviour
{
    private string characterSelectP1;

    [SerializeField] private GameObject player1Archer;
    [SerializeField] private GameObject player1Gladiator;
    [SerializeField] private GameObject player1Warlock;

    [SerializeField] private Transform player1Spawn;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelect");

        characterSelectP1 = characterSelect.GetComponent<CharacterSelect>().playerCharacter1;

        if(characterSelectP1 == "P1Archer")
        {
            Instantiate(player1Archer, player1Spawn.position, player1Spawn.rotation);
        }

        if(characterSelectP1 == "P1Gladiator")
        {
            Instantiate(player1Gladiator, player1Spawn.position, player1Spawn.rotation);
        }

        if(characterSelectP1 == "P1Warlock")
        {
            Instantiate(player1Warlock, player1Spawn.position, player1Spawn.rotation);
        }
    }
}
