using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnDestroy()
    {
        EnemyCounterUI enemyCounter = FindObjectOfType<EnemyCounterUI>();
        if (enemyCounter != null)
        {
            enemyCounter.EnemyDefeated();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);  // Elimina el enemigo
    }
}
