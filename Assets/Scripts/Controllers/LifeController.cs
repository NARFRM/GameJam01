using UnityEngine;


public class LifeController : MonoBehaviour
{

    [SerializeField] protected int lives; // Vidas del jugador
    public bool didLose; // Variable para saber si el jugador perdió

    public static LifeController Instance { get; private set; }

    public void Awake()
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
        lives = 3;

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ReduceLife(float damage)
    {
        lives -= (int)damage;
        Debug.Log("Vidas restantes: " + lives);

        if (lives <= 0)
        {
            didLose = true;
            GameManager.Instance.GameOverLose(didLose);
        }
    }
}
