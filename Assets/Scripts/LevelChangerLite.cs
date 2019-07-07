using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerLite : MonoBehaviour
{
    //reference to animator
    public Animator animator;

    //level that needs to be loaded
    private int levelToLoad;

    //function for when we want to fade to something, like a the level
    public void FadeTo(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
}
