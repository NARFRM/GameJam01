using UnityEngine;
using System.Collections;

public class LaserBlinking : LaserBase
{
    [SerializeField] private float blinkInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void InitializeLaser()
    {
        InvokeRepeating("ChangeVisibility", 2f, blinkInterval);
    }


    void ChangeVisibility()
    // TODO: Cambiar para que solo suceda cuando el juegador esté vivo y no muerto por medio de un if
    {
        isActive = !isActive; // Alternar estado
        gameObject.SetActive(isActive); // Activar/desactivar visualmente
    }
}
