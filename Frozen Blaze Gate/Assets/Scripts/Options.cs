using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;


    public AudioSource ambianceSound;
    public AudioSource doorCloseSound;
    public AudioSource doorOpenSound;
    public AudioSource launchSound;
    public Slider volumeSlider;

    public Toggle fullscreenToggle;
    private bool _fullscreen;
    
    private void Start()
    {
        CheckFullscreen();
        CheckResolution();
        CheckGraphics();
        CheckVolume();
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        int graphicsChoice = PlayerPrefs.GetInt("Graphics");
        graphicsDropdown.value = graphicsChoice;
        int resolutionChoice = PlayerPrefs.GetInt("Resolution");
        resolutionDropdown.value = resolutionChoice;
        bool fullscreenBool = (PlayerPrefs.GetInt("Fullscreen") == 1) ? true : false;
        fullscreenToggle.isOn = fullscreenBool;
    }
    
    // Update is called once per frame
    private void Update()
    {
    }
    
    private void CheckVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
           ambianceSound.volume = PlayerPrefs.GetFloat("Volume");
           launchSound.volume = PlayerPrefs.GetFloat("Volume");
           doorCloseSound.volume = PlayerPrefs.GetFloat("Volume");
           doorOpenSound.volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1);
            ambianceSound.volume = 1;
            launchSound.volume = 1;
            doorCloseSound.volume = 1;
            doorOpenSound.volume = 1;
        }
    }

    public void VolumeValue()
    {
        float value = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", value);
        CheckVolume();
        
    }
    
    private void CheckFullscreen()
    {
        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            if (PlayerPrefs.GetInt("Fullscreen") > 0)
            {
                Screen.fullScreen = true;
            }
            else
            {
                Screen.fullScreen = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
            Screen.fullScreen = true;
        }
    }
    
    public void FullscreenBool(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
        CheckFullscreen();
    }

    private void CheckResolution()
    {
        bool fullscreenBool = (PlayerPrefs.GetInt("Fullscreen") == 1) ? true : false;
        if (PlayerPrefs.HasKey("Resolution"))
        {
            switch (PlayerPrefs.GetInt("Resolution"))
            {
                case 0:
                    Screen.SetResolution(1920, 1080, fullscreenBool);
                    break;
                case 1:
                    Screen.SetResolution(1280, 720, fullscreenBool);
                    break;
                case 2:
                    Screen.SetResolution(854, 480, fullscreenBool);
                    break;
                case 3:
                    Screen.SetResolution(640, 360, fullscreenBool);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Resolution", 0);
            Screen.SetResolution(1920, 1080, fullscreenBool);
        }
    }

    public void ResolutionChoice() 
    {
        switch (resolutionDropdown.value) 
        {
            case 0:
                PlayerPrefs.SetInt("Resolution", 0);
                break;
            case 1:
                PlayerPrefs.SetInt("Resolution", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Resolution", 2);
                break;
            case 3:
                PlayerPrefs.SetInt("Resolution", 3);
                break;
        }
        CheckResolution();
    }
    
    private void CheckGraphics()
    {
        if (PlayerPrefs.HasKey("Graphics"))
        {
            switch (PlayerPrefs.GetInt("Graphics"))
            {
                case 0:
                    QualitySettings.SetQualityLevel(0);
                    break;
                case 1:
                    QualitySettings.SetQualityLevel(1);
                    break;
                case 2:
                    QualitySettings.SetQualityLevel(2);
                    break;
                case 3:
                    QualitySettings.SetQualityLevel(3);
                    break;
                case 4:
                    QualitySettings.SetQualityLevel(4);
                    break;
                case 5:
                    QualitySettings.SetQualityLevel(5);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Graphics", 5);
        }
    }

    public void GraphicsChoice()
    {
        switch (graphicsDropdown.value) 
        {
            case 0:
                PlayerPrefs.SetInt("Graphics", 0);
                break;
            case 1:
                PlayerPrefs.SetInt("Graphics", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Graphics", 2);
                break;
            case 3:
                PlayerPrefs.SetInt("Graphics", 3);
                break;
            case 4:
                PlayerPrefs.SetInt("Graphics", 4);
                break;
            case 5:
                PlayerPrefs.SetInt("Graphics", 5);
                break;
        }
        CheckGraphics();
    }
}
