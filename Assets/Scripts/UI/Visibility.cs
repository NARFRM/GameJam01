using UnityEngine;

public class Visibility : MonoBehaviour
{
    [SerializeField] private float blinkInterval = 1f;

    void Start()
    {
        InvokeRepeating("ChangeVisibility", 2f, blinkInterval);
    }

    void ChangeVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }


}
