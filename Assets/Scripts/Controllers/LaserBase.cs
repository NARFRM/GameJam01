using UnityEngine;

public abstract class LaserBase : MonoBehaviour
{
    [SerializeField] protected float damage = 1f; // Daño del láser
    [SerializeField] protected bool isActive = true; // Estado del láser

    protected virtual void Start()
    {
        InitializeLaser();
    }

    protected abstract void InitializeLaser(); // Cada láser tendrá su propia inicialización

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) {
            Debug.Log("Choca con el laser");
            GameManager.instance.ReduceLife(damage);
        }

        // TODO : Implementar un canvas de damage (rojo) para mostrar el daño recibido
        // TODO: Una animación de daño
    }


}
