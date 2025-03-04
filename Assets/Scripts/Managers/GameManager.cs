using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 10;

    public bool isGameOver = false;

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

    public void ReduceLife(float damage)
    {
        lives -= (int)damage;
        Debug.Log("Vidas restantes: " + lives);
        if(lives <= 0)
        {
            isGameOver = true;
        }
    }

}
