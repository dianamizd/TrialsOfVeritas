using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// The scene we want to load.
    /// </summary>
    //[SerializeField] private int sceneIndex;
    
    /// <summary>
    /// The scene to load.
    /// </summary>
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
