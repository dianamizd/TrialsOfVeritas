using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    //variable for panel
    [SerializeField] private Image howToPanel;

    //when the game starts, the menu is closed
    private void Start()
    {
        howToPanel.enabled = false;

        for (int i=0; i<howToPanel.transform.childCount; ++i)
        {
            var child = howToPanel.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
    }

    //when the How to play button is pressed, it'll be anabled
    public void HowTo()
    {
        howToPanel.enabled = true;

        for (int i = 0; i < howToPanel.transform.childCount; ++i)
        {
            var child = howToPanel.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(true);
            }
        }
    }

    //when the window is closed, it'll be disabled again
    public void CloseHowTo()
    {
        howToPanel.enabled = false;

        for (int i = 0; i < howToPanel.transform.childCount; ++i)
        {
            var child = howToPanel.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
    }
}
