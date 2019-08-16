using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int playerCharacter1 = 1;

    public int playerCharacter2 = 1;

    public GameObject Destroythis;
        

    private void Awake()
    {
        playerCharacter1 = 1;

        playerCharacter2 = 1;
            
    }

    public void ArcherP1()
    {
        Debug.Log("P1 Archer Selected");
        playerCharacter1 = 1; 
    }

    public void GladiatorP1()
    {
        Debug.Log("P1 Gladiator Selected");
        playerCharacter1 = 2;
    }
    public void WarlockP1()
    {
        Debug.Log("P1 Warlock Selected");
        playerCharacter1 = 3;
    }
    public void ArcherP2()
    {
        Debug.Log("P2 Archer Selected");
        playerCharacter2 = 1;
    }
    public void GladiatorP2()
    {
        Debug.Log("P1 Archer Selected");
        playerCharacter2 = 2;
    }
    public void WarlockP2()
    {
        Debug.Log("P1 Archer Selected");
        playerCharacter2 = 3;
    }

}
