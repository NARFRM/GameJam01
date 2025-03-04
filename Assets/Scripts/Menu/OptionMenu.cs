using UnityEngine;
using UnityEngine.UI;  

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;   
    public Text volumeText;       

    void Start()
    {
       
        volumeSlider.value = AudioListener.volume;

     
        UpdateVolumeText();

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

   
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        UpdateVolumeText();
    }

    
    void UpdateVolumeText()
    {
        volumeText.text = "Volumen: " + Mathf.RoundToInt(AudioListener.volume * 100) + "%";
    }
}
