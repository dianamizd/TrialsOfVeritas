using CharacterSelector.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCharacterSelect : MonoBehaviour {

    public InputField CharacterName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchCharacter()
    {
        // e.g. Ethan or Rabbit
        string characterName = transform.Find("Text").GetComponent<Text>().text;

        CharacterManager.Instance.SetCurrentCharacterType(characterName);

    }

    public void CreateCharacter()
    {
        CharacterManager.Instance.CreateCurrentCharacter(CharacterName.text);
    }
}
