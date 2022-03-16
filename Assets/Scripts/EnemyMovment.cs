using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovment : Enemy
{
    public UnityEvent onEnemyFinishFirstMove;
    public UnityEvent enemyFinishMoving;
    [SerializeField]
    private float movementTime = 0.95f;
    private const int moveLong = 40;
    private int cSquareNu;
    private tileItem[] grid;
    private bool firstMove;

    public void SetData(tileItem[] grid, int minotaur_Pos, Vector3 localPosition)
    {
        this.grid = grid;
        cSquareNu = minotaur_Pos;
        rectTransform.anchoredPosition = localPosition;
    }

    public void MoveEnemy(Direction direction, bool firstMove)
    {
        if (direction == Direction.none || !CanMoveThisDirection(direction))
        {
            enemyFinishMoving.Invoke();
            return;
        }
        this.firstMove = firstMove;
        SetNewSquareNu(direction);
        StartCoroutine(MoveEnemyCor(direction));
    }

    public bool CanMoveThisDirection(Direction direction)
    {
        if (isThereBorder(grid[cSquareNu].getTile(), direction))
            return false;
        return true;
    }

    private bool isThereBorder(TileO tile, Direction direction)
    {
        return tile.borders[(int)direction] == 1;
    }

    private void SetNewSquareNu(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                cSquareNu -= 10; break;
            case Direction.down:
                cSquareNu += 10; break;
            case Direction.left:
                cSquareNu -= 1; break;
            case Direction.right:
                cSquareNu += 1; break;
        }
    }

    private IEnumerator MoveEnemyCor(Direction direction)
    {
        Vector3 startingPos = rectTransform.localPosition;
        Vector3 finalPos = GetFinalPos(direction);
        float elapsedTime = 0;
        while (elapsedTime < movementTime)
        {
            rectTransform.localPosition = Vector3.Lerp(startingPos, finalPos, (elapsedTime / movementTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rectTransform.localPosition = finalPos;
        if (firstMove)
        {
            onEnemyFinishFirstMove.Invoke();
            GetEnemyAI().MoveEnemy();
        }
        else
            enemyFinishMoving.Invoke();
    }

    private Vector2 GetFinalPos(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y + moveLong);
            case Direction.down:
                return new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y - moveLong);
            case Direction.left:
                return new Vector2(rectTransform.localPosition.x - moveLong, rectTransform.localPosition.y);
            case Direction.right:
                return new Vector2(rectTransform.localPosition.x + moveLong, rectTransform.localPosition.y);
            default:
                return new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y + moveLong);
        }
    }

    public int GetNextSquareNu(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return cSquareNu - 10;
            case Direction.down:
                return cSquareNu + 10;
            case Direction.left:
                return cSquareNu - 1;
            case Direction.right:
                return cSquareNu + 1;
            default: return cSquareNu - 10;
        }
    }

    public int GetCurrentPos() { return cSquareNu; }
}
