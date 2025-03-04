using UnityEngine;

public class LaserStatic : LaserBase
{
    protected override void InitializeLaser()
    {
        isActive = true; // Siempre encendido
    }

    void Start()
    {
        Debug.Log("Inicia el laser");
    }

    

    

}
