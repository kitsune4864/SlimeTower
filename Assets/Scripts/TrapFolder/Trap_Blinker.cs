using System.Collections;
using UnityEngine;

public class Trap_Blinker : MonoBehaviour
{
    private enum LightState
    {
        Red,
        Yellow,
        Green,
    }
    [SerializeField]
    private Light redLight;
    
    [SerializeField]
    private Light yellowLight;
    
    [SerializeField]
    private Light greenLight;

    [SerializeField]
    private LightState lState;

    [SerializeField]
    private float blinkCount;
    
    [SerializeField]
    private Trap_Train trapTrain;

    [SerializeField]
    private float greenLightTimer;

    [SerializeField] 
    private BoxCollider bBC;
    void Start()
    {
        
        
        lState = LightState.Red;
        blinkCount = 0;
        redLight.intensity = 1f;
        yellowLight.intensity = 0f;
        greenLight.intensity = 0f;

        

        StartCoroutine(YellowRightController());
    }

    
    void Update()
    {
        if (trapTrain == null)
        {
            trapTrain = FindObjectOfType<Trap_Train>();
        }
        
        blinkCount += Time.deltaTime;
    }
    

    private IEnumerator YellowRightController()
    {
        while(true)
        {
            if (blinkCount < 20)
            {
                lState = LightState.Red;
                redLight.intensity = 1f;

                yield return null;
                continue;

            }
            
            if (blinkCount >= 20)
            {
                redLight.intensity = 0f;

                lState = LightState.Yellow;
                yellowLight.intensity = 1f;
                yield return new WaitForSeconds(1f);
                yellowLight.intensity = 0f;

                lState = LightState.Green;
                greenLight.intensity = 1f;
                yield return new WaitForSeconds(greenLightTimer);
                greenLight.intensity = 0f;
                blinkCount = 0;
                
                yield return null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (lState == LightState.Red || lState == LightState.Yellow)
        {
            if (other.CompareTag("Player"))
            {
                trapTrain.TrainStrikeDetected();
            }
        }
    }
}
