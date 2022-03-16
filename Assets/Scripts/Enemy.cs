using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected EnemyManager enemyManager;
    protected PlayerManager playerManager;

    protected virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        enemyManager = GetComponent<EnemyManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    protected virtual EnemyAI GetEnemyAI() { return enemyManager.getEnemyAI(); }
    protected virtual EnemyMovment GetEnemyMovment() { return enemyManager.getEnemyMovement(); }
    protected virtual EnemyPosition GetEnemyPosition() { return enemyManager.getEnemyPosition(); }
    protected virtual PlayerManager GetPlayerManager() { return playerManager; }
}