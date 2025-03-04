using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Singleton para acceder fácilmente
    public int enemigosRestantes = 5;
    public TextMeshProUGUI textoEnemigos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarTextoEnemigos();
    }

    public void EnemigoEliminado()
    {
        enemigosRestantes--;
        if (enemigosRestantes < 0) enemigosRestantes = 0;

        ActualizarTextoEnemigos();

        if (enemigosRestantes == 0)
        {
            Victoria();
        }
    }

    void ActualizarTextoEnemigos()
    {
        textoEnemigos.text = "Enemigos restantes: " + enemigosRestantes;
    }

    void Victoria()
    {
        Debug.Log("¡Has eliminado a todos los enemigos!");
        // Aquí puedes cambiar de escena o mostrar una pantalla de victoria
    }
}
