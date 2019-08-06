using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{ 
    private GameObject[] characterList;

    private int index;

    private void Start()
    {
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[0])
            characterList[0].SetActive(true);
    }

    public void ToggleRight()
    {
        //toggle current model off
        characterList[index].SetActive(false);

        //cycle through models
        index++;
        if (index == characterList.Length)
            index = 0;

        //toggle next model on
        characterList[index].SetActive(true);
    }

    public void ToggleLeft()
    {
        //toggle current model off
        characterList[index].SetActive(false);

        //cycle through models
        index--;
        if (index < 0)
            index = characterList.Length - 1;
        
        //toggle next model on
        characterList[index].SetActive(true);
    }
    
    
}
