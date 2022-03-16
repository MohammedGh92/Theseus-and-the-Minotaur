using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : Player
{

    private int cPos;

    public int GetCurrentPos()
    {
        return cPos;
    }

    public void SetLastPos()
    {
        cPos = GetPlayerMovement().GetCurrentPos();
    }

    public void SetData(int squareNu, Vector2 targetPos)
    {
        cPos = squareNu;
        rectTransform.anchoredPosition = targetPos;
    }
}