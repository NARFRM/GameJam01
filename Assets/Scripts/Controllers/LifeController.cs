using UnityEngine;


public class LifeController : MonoBehaviour
{

    [SerializeField] protected int lives; // Vidas del jugador
    public bool didLose; // Variable para saber si el jugador perdió

    public static LifeController instance { get; private set; }

    public void Awake()
    {
        if(instance == null)
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
        lives = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ReduceLife(float damage)
    {
        lives -= (int)damage;
        Debug.Log("Vidas restantes: " + lives);

        if(lives <= 0)
        {
            didLose = true;
            GameManager.instance.GameOverLose(didLose);
        }
    }
}
