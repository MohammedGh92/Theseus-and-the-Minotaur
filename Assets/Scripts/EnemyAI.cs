using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Enemy
{

    private tileItem[] grid;
    [SerializeField]
    private int minDis;
    private Direction direction;

    public void SetData(tileItem[] grid)
    {
        this.grid = grid;
    }

    public void MoveEnemy(bool firstMove = false)
    {
        if (playerManager.getPlayerWin().isPlayerEscaped())
        {
            print("player escaped!");
            return;
        }
        if (playerManager.getPlayerLife().isPlayerDead())
        {
            print("player is Dead!");
            return;
        }
        Direction nextMoveDir = FindNextBestMove();
        GetEnemyMovment().MoveEnemy(nextMoveDir, firstMove);
    }

    private Direction FindNextBestMove()
    {
        int cPlayerPos = playerManager.getPlayerPosition().GetCurrentPos();

        minDis = getMinDis(cPlayerPos);
        direction = Direction.none;

        if (checkDirection(Direction.left, cPlayerPos))
            direction = Direction.left;
        else if (checkDirection(Direction.right, cPlayerPos))
            direction = Direction.right;
        else if (checkDirection(Direction.up, cPlayerPos))
            direction = Direction.up;
        else if (checkDirection(Direction.down, cPlayerPos))
            direction = Direction.down;
        return direction;
    }

    private int getMinDis(int cPlayerPos)
    {
        int result = int.MaxValue;

        if (calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.left)) < result)
            result = calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.left));
        if (calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.right)) < result)
            result = calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.right));
        if (calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.up)) < result)
            result = calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.up));
        if (calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.down)) < result)
            result = calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(Direction.down));
        return result;
    }

    private bool checkDirection(Direction direction, int cPlayerPos)
    {
        int distance = calcDistance(cPlayerPos, GetEnemyMovment().GetNextSquareNu(direction));
        if (distance <= minDis && GetEnemyMovment().CanMoveThisDirection(direction))
            return true;
        return false;
    }

    private int calcDistance(int cPlayerPos, int cEnemyPos)
    {
        int cPlayerRow = cPlayerPos.ToString("00")[0];
        int cPlayerCol = cPlayerPos.ToString("00")[1];
        int cEnemyRow = cEnemyPos.ToString("00")[0];
        int cEnemyCol = cEnemyPos.ToString("00")[1];
        return Mathf.Abs(cPlayerRow - cEnemyRow) + Mathf.Abs(cPlayerCol - cEnemyCol);
    }
}
