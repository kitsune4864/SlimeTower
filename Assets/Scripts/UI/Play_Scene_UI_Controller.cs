using UnityEngine;
using UnityEngine.UI;

public class Play_Scene_UI_Controller : MonoBehaviour
{
    [SerializeField] 
    private TPSCameraPureOrbit_Unity6 cameraMouse;
    
    [SerializeField]
    private Slider sensitivitySlider;
    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(ChangeSensitivity);
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 100f);
    }


    private void ChangeSensitivity(float newValue)
    {
        cameraMouse.MouseSensitivityController(newValue);
        PlayerPrefs.SetFloat("MouseSensitivity", newValue);
    }

    public void RestartGameOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .buildIndex);
        Time.timeScale = 1;
    }

    public void ExitGameOnClick()
    {
        Application.Quit();
    }
}
