using UnityEngine;

public class LaserMotionSensor : MonoBehaviour
{

    public GameObject laser1;
    public GameObject laser2;


    
    // Detectar colisión física
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");

        laser1.SetActive(true);
        laser2.SetActive(true);

    }

    void OnTriggerExit(Collider other){
        Debug.Log("Salir del trigger: " + other.gameObject.name);

        laser1.SetActive(false);
        laser2.SetActive(false);

    }
}
