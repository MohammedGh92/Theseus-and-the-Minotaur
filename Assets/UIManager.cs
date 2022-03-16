using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text levelTxt;
    [SerializeField]
    private GameObject winGo;
    [SerializeField]
    private GameObject loseGo;

    private void Start()
    {
        SetData(LevelManager.GetcLevel());
    }

    public void SetData(int cLevel)
    {
        levelTxt.text = "Level:" + (int)(cLevel + 1);
    }

    public void ShowWin()
    {
        winGo.SetActive(true);
    }

    public void ShowLose()
    {
        loseGo.SetActive(true);
    }

}