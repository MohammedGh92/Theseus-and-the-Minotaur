using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : Player
{

    [SerializeField]
    public UnityEvent playerIsDead;
    private bool playerisDead;

    public void CheckPlayerDeath()
    {
        if (GetPlayerPosition().GetCurrentPos() == enemyManager.getEnemyPosition().GetCurrentPos())
        {
            playerisDead = true;
            playerIsDead.Invoke();
        }
    }

    public bool isPlayerDead() { return playerisDead; }

}