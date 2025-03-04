using UnityEngine;
using UnityEngine.UI;

public class VidasManager : MonoBehaviour
{
    public Image[] corazones; // Arreglo de im�genes de corazones
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    private int vidas = 3; // Cantidad inicial de vidas

    void Start()
    {
        ActualizarVidas();
    }

    public void PerderVida()
    {
        vidas--;
        if (vidas < 0) vidas = 0;
        ActualizarVidas();
    }

    private void ActualizarVidas()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidas)
            {
                corazones[i].sprite = corazonLleno; // Muestra coraz�n lleno
            }
            else
            {
                corazones[i].sprite = corazonVacio; // Muestra coraz�n vac�o
            }
        }
    }
}
