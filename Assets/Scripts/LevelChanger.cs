using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    //reference to animator
    public Animator animator;

    //level that needs to be loaded
    private int levelToLoad;

    //buttons for both the levels
    public Button islandButton;
    public Button lavaButton;

    //on button presses, it will go to it's specified level
    private void Start()
    {
        //when uncommented, an error comes up but i can;t find the issue with it...
        islandButton.onClick.AddListener(IslandLevel);
        lavaButton.onClick.AddListener(LavaLevel);
    }

    //function for when we want to fade to something, like a the level
    public void FadeTo(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    //listener to call to island level
    public void IslandLevel()
    {
        //as long as the + no. is the accurate number of scenes after the level select, it should work
        FadeTo(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //listener to call to lava level
    public void LavaLevel()
    {
        FadeTo(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //on fadeout animation, we want new scene to load
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
