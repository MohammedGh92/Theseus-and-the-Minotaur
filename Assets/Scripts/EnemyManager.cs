using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyMovment enemyMovment;
    private EnemyPosition enemyPosition;
    private EnemyAI enemyAI;

    private void Awake()
    {
        SetRefs();
    }

    private void SetRefs()
    {
        enemyMovment = GetComponent<EnemyMovment>();
        enemyPosition = GetComponent<EnemyPosition>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void SetData(tileItem[] grid, LevelO level, Vector3 localPosition)
    {
        enemyMovment.SetData(grid, level.minotaur_Pos, localPosition);
        enemyPosition.SetData(level.minotaur_Pos, localPosition);
        enemyAI.SetData(grid);
    }

    public EnemyMovment getEnemyMovement() { return enemyMovment; }
    public EnemyPosition getEnemyPosition() { return enemyPosition; }
    public EnemyAI getEnemyAI() { return enemyAI; }
}
