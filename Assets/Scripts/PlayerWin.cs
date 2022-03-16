using UnityEngine;
using UnityEngine.Events;

public class PlayerWin : Player
{
    private int winSquareNu;
    private bool playerEscaped;
    public UnityEvent playerWin;

    public void SetData(int winSquareNu)
    {
        this.winSquareNu = winSquareNu;
    }

    public void CheckPlayerWin()
    {
        if (GetPlayerPosition().GetCurrentPos() == winSquareNu)
        {
            playerEscaped = true;
            print("Win");
            playerWin.Invoke();
        }
    }

    public bool isPlayerEscaped()
    {
        return playerEscaped;
    }
}