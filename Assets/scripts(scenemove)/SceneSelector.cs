using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public SceneButton[] sceneButtons;
    private int currentIndex = 0;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % sceneButtons.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex = (currentIndex - 1 + sceneButtons.Length) % sceneButtons.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneButtons[currentIndex].sceneName);
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < sceneButtons.Length; i++)
        {
            sceneButtons[i].Highlight(i == currentIndex);
        }
    }
}