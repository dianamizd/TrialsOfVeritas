using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string playerCharacter1;

    public string playerCharacter2;
        

    private void Start()
    {
        playerCharacter1 = "P1Archer";

        playerCharacter2 = "P2Archer";
            
    }

    public void ArcherP1()
    {
        Debug.Log("P1 Archer Selected");
        playerCharacter1 = "P1Archer"; 
    }

    public void GladiatorP1()
    {
        Debug.Log("P1 Gladiator Selected");
        playerCharacter1 = "P1Gladiator";
    }
    public void WarlockP1()
    {
        Debug.Log("P1 Warlock Selected");
        playerCharacter1 = "P1Warlock";
    }
    public void ArcherP2()
    {
        Debug.Log("P2 Archer Selected");
        playerCharacter2 = "P2Archer";
    }
    public void GladiatorP2()
    {
        Debug.Log("P2 Gladiator Selected");
        playerCharacter2 = "P2Gladiator";
    }
    public void WarlockP2()
    {
        Debug.Log("P2 Warlock Selected");
        playerCharacter2 = "P2Warlock";
    }

}
