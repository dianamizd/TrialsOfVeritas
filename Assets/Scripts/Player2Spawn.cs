using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawn : MonoBehaviour
{
    private int characterSelectP2;

    public GameObject P2Archer;
    public GameObject P2Gladiator;
    public GameObject P2Warlock;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("Character Select");

        characterSelectP2 = characterSelect.GetComponent<CharacterSelect>().playerCharacter2;

        if (characterSelectP2 == 1)
        {
            P2Archer.SetActive(true);
            P2Gladiator.SetActive(false);
            P2Warlock.SetActive(false);

            Destroy(characterSelect);
        }

        if (characterSelectP2 == 2)
        {
            P2Archer.SetActive(false);
            P2Gladiator.SetActive(true);
            P2Warlock.SetActive(false);

            Destroy(characterSelect);
        }

        if (characterSelectP2 == 3)
        {
            P2Archer.SetActive(false);
            P2Gladiator.SetActive(false);
            P2Warlock.SetActive(true);

            Destroy(characterSelect);
        }
    }
}
