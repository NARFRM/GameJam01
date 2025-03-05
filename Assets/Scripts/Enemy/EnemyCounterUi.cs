using UnityEngine;
using TMPro;  // Necesario para manejar TextMeshPro

public class EnemyCounterUI : MonoBehaviour
{
    public TextMeshProUGUI enemyText;  // Referencia al texto en la UI
    private int remainingEnemies;  // Cantidad de enemigos

    void Start()
    {
        remainingEnemies = FindObjectsOfType<Enemy>().Length; // Cuenta los enemigos al iniciar
        UpdateEnemyUI();
    }

    public void EnemyDefeated()
    {
        remainingEnemies--;  // Reduce la cantidad de enemigos
        UpdateEnemyUI();
    }

    void UpdateEnemyUI()
    {
        enemyText.text = "Enemigos restantes: " + remainingEnemies; // Actualiza el texto
    }
}
