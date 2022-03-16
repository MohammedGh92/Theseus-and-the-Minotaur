using UnityEngine;

public class EnemyPosition : Enemy
{
    private int cPos;

    public int GetCurrentPos()
    {
        return cPos;
    }

    public void SetLastPos()
    {
        cPos = GetEnemyMovment().GetCurrentPos();
    }

    public void SetData(int squareNu, Vector2 targetPos)
    {
        cPos = squareNu;
        rectTransform.anchoredPosition = targetPos;
    }
}