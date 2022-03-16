using UnityEngine;

public class Player : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected PlayerManager playerManager;
    protected EnemyManager enemyManager;

    protected virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        playerManager = GetComponent<PlayerManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    protected virtual PlayerLife GetPlayerLife() { return playerManager.getPlayerLife(); }
    protected virtual PlayerMovement GetPlayerMovement() { return playerManager.getPlayerMovement(); }
    protected virtual PlayerPosition GetPlayerPosition() { return playerManager.getPlayerPosition(); }
    protected virtual PlayerWin GetPlayerWin() { return playerManager.getPlayerWin(); }
    protected virtual EnemyManager GetEnemyManager() { return enemyManager; }
}
