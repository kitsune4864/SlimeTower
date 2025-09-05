using UnityEngine;
using UnityEngine.UI;

public class Play_Scene_Mouse_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsCanvas;

    [SerializeField] 
    private TPSCameraPureOrbit_Unity6 cameraMouse;
    
    [SerializeField]
    private bool isPaused = false;
    void Start()
    {
        isPaused = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
               Resume();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        settingsCanvas.gameObject.SetActive(true);
        cameraMouse.SetCursorLock(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        settingsCanvas.gameObject.SetActive(false);
        cameraMouse.SetCursorLock(true);
        Time.timeScale = 1;
    }
}
