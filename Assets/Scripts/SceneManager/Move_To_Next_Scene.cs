using System;
using UnityEngine;

public class Move_To_Next_Scene : MonoBehaviour
{
    [SerializeField]
    private int sceneNumber;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
        }
    }
}
