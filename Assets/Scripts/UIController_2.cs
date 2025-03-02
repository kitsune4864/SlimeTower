using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController_2 : MonoBehaviour
{
    public PlayerStateManager_2 _playerStateManager;
    public GameObject leftClickUI;
    public GameObject leftClickWhite;
    public GameObject leftClickBlack;

    private Coroutine curUICoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIStructure"))
        {
            ShowLeftClickUI();
            _playerStateManager.curStructureTransform = other.transform.parent.transform;
            _playerStateManager.canSink = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UIStructure"))
        {
            DisableLeftClickUI();
        }
        _playerStateManager.canSink = false;
    }

    public void ShowLeftClickUI()
    {
        leftClickUI.SetActive(true);
        //FIXME : 추후 효과 추가
        BlinkUI(leftClickWhite, leftClickBlack);
    }

    private void DisableLeftClickUI()
    {
        StopCoroutine(curUICoroutine);
        leftClickUI.SetActive(false);
    }


    private void BlinkUI(GameObject obj1, GameObject obj2)
    {
        curUICoroutine = StartCoroutine(BlinkUICoroutine(obj1, obj2));
    }
    IEnumerator BlinkUICoroutine(GameObject obj1, GameObject obj2)
    {
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while (true)
        {
            if (obj1.activeSelf== true)
            {
                obj1.SetActive(false);
                obj2.SetActive(true);
            }
            else
            {
                obj1.SetActive(true);
                obj2.SetActive(false);
            }
            yield return waitTime;
        }
    }
}
