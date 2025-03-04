using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int vidas = 3;
    public int enemigosRestantes = 5;

    void Awake()
    {
        // Asegura que solo exista un GameManager en la escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PerderVida()
    {
        vidas--;
        if (vidas <= 0)
        {
            GameOver();
        }
    }

    public void EnemigoEliminado()
    {
        enemigosRestantes--;
        if (enemigosRestantes <= 0)
        {
            Victoria();
        }
    }

    void GameOver()
    {
        Debug.Log("¡Game Over!");
        // Aquí puedes cargar una pantalla de Game Over
    }

    void Victoria()
    {
        Debug.Log("¡Ganaste!");
        // Aquí puedes pasar al siguiente nivel
    }
}
