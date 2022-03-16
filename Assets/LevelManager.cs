using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private static int cLevel;

    public void StartLevel(int levelNu)
    {
        cLevel = levelNu;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void StartNextLevel()
    {
        if (cLevel < 2)
            StartLevel(cLevel + 1);
    }

    public void StartPrevLevel()
    {
        if (cLevel > 0)
            StartLevel(cLevel - 1);
    }

    public static int GetcLevel()
    {
        return cLevel;
    }

}