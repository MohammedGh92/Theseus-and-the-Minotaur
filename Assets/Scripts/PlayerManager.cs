using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private PlayerPosition playerPosition;
    private PlayerLife playerLife;
    private PlayerWin playerWin;

    private void Awake()
    {
        SetRefs();
    }

    private void SetRefs()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerPosition = GetComponent<PlayerPosition>();
        playerLife = GetComponent<PlayerLife>();
        playerWin = GetComponent<PlayerWin>();
    }

    public void SetData(tileItem[] grid, LevelO level, Vector3 localPosition)
    {
        playerMovement.SetData(grid, level.theseus_Pos, localPosition);
        playerPosition.SetData(level.theseus_Pos, localPosition);
        playerWin.SetData(level.escape_Pos);
    }

    public PlayerMovement getPlayerMovement() { return playerMovement; }
    public PlayerPosition getPlayerPosition() { return playerPosition; }
    public PlayerLife getPlayerLife() { return playerLife; }
    public PlayerWin getPlayerWin() { return playerWin; }

}