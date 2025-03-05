using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para manejar las escenas

public class MainMenu : MonoBehaviour
{
 
    public void StartGame()
    {
        // Asegúrarse de que el nombre de la escena sea correcto.
        SceneManager.LoadScene("Level1");
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Solo funciona en el juego compilado
    }
}
