using UnityEngine;
using UnityEngine.SceneManagement; // Importamos SceneManager para gestionar las escenas.
using System.Collections; // Importamos System.Collections para usar IEnumerator.

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } // Propiedad para acceder a la instancia (Singleton).

       public bool isGameOver = false;

     public bool didLose; // Variable para saber si el jugador perdió.
    
    public bool isPaused; // Variable para saber si el juego está pausado.

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        didLose = false; // Inicializa la variable en false.   
        isPaused = false; // Inicializa la variable en false. 
        
    }

    public void GamePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Freeze the game           
        }
        else
        {
            Time.timeScale = 1f; // Resume the game           
        }
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.P))
    {
        GamePause();
    }
    }

   

    public void GameOverLose (bool lose)
    {
       if (lose) // Si el jugador perdió
       {
            RestartScene(); // Reinicia la escena.
            Debug.Log("Game Over"); // Muestra un mensaje en la consola.
       }
       
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual.
    }

     IEnumerator LoadFinishScene()
    {
    yield return new WaitForSeconds(1f); // Espera 1 segundo antes de recargar
    SceneManager.LoadScene("Finish");
    }

    public void GameOverWin (bool winner)
    {
        if (winner) // Si el jugador ganó
        {
            CountScenes(); // Carga la siguiente escena.
            Debug.Log("You Win!"); // Muestra un mensaje en la consola.            
           
        }

        
    }  

    public void CountScenes()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        Debug.Log("Cargando escena: " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex); // Carga la siguiente escena
    }
    else
    {
        Debug.Log("Última escena alcanzada. Cargando escena de reinicio...");
        
    }
    } 

    public void RestartGame()
    {
        // Resetear cualquier variable global
        didLose = false;
        isPaused = false;

        // Cargar la primera escena
        SceneManager.LoadScene(1);

        // Opcional: Si GameManager usa DontDestroyOnLoad, puedes resetearlo manualmente
        instance = null;
        Destroy(gameObject);
    }
  


}
