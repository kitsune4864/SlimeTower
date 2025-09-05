using System;
using UnityEngine;

public class LanguageSelector_Button : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource buttonSound;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void SetKorean()
    {
        LocalizationManager.SetLanguage(SystemLanguage.Korean);
        buttonSound.Play();
    }

    public void SetEnglish()
    {
        LocalizationManager.SetLanguage(SystemLanguage.English);
        buttonSound.Play();
    }
}
