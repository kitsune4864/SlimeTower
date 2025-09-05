using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Scene_UI_Controller : MonoBehaviour
{
    [SerializeField] 
    private Image settingImage;
    
    [SerializeField]
    private AudioSource buttonSound;
    
    
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }
    

    public void GameStartButtonOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        buttonSound.Play();
    }

    public void GameEndButtonOnClick()
    {
        Application.Quit();
       
    }

    public void SettingsButtonOnClick()
    {
        settingImage.gameObject.SetActive(true);
        buttonSound.Play();
    }

    public void SettingsButtonOff()
    {
        settingImage.gameObject.SetActive(false);
        buttonSound.Play();
    }
}
