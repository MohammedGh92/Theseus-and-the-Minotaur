using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : Player
{

    public UnityEvent playerFinishMoving;
    [SerializeField]
    private float movementTime = 0.75f;
    private const int moveLong = 40;
    private bool canMove;
    private int cSquareNu;
    private tileItem[] grid;


    public void SetData(tileItem[] grid, int theseus_Pos, Vector3 localPosition)
    {
        this.grid = grid;
        cSquareNu = theseus_Pos;
        rectTransform.anchoredPosition = localPosition;
        canMove = true;
    }

    public void MovePlayer(int direction)
    {
        if (GetPlayerLife().isPlayerDead())
            return;
        MovePlayer((Direction)direction);
    }

    private void MovePlayer(Direction direction)
    {
        if (!canMove)
            return;
        if (direction == Direction.none)
        {
            playerFinishMoving.Invoke();
            return;
        }
        if (!CanMoveThisDirection(direction))
            return;
        SetNewSquareNu(direction);
        StartCoroutine(MovePlayerCor(direction));
    }

    private bool CanMoveThisDirection(Direction direction)
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

    private IEnumerator MovePlayerCor(Direction direction)
    {
        canMove = false;
        Vector3 startingPos = rectTransform.localPosition;
        Vector3 finalPos = GetFinalPos(direction);
        float elapsedTime = 0;
        while (elapsedTime < movementTime)
        {
            rectTransform.localPosition = Vector3.Lerp(startingPos, finalPos, elapsedTime / movementTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rectTransform.localPosition = finalPos;
        playerFinishMoving.Invoke();
    }

    public void SetPlayerCanMove()
    {
        canMove = true;
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

    public int GetCurrentPos() { return cSquareNu; }
}