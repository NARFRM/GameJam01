using UnityEngine;
using TMPro;  // Necesario para manejar TextMeshPro

public class EnemyCounterUI : MonoBehaviour
{
    public static EnemyCounterUI Instance { get; private set; }
    public TextMeshProUGUI enemyText;
    private int remainingEnemies;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");
        remainingEnemies = npcs.Length;
        UpdateEnemyUI();
    }

    public void EnemyDefeated()
    {
        remainingEnemies--;
        UpdateEnemyUI();
    }

    void UpdateEnemyUI()
    {
        enemyText.text = "Crew members alive: " + remainingEnemies;
    }
}
