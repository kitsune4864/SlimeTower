using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Fire_Breath_Effect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem fireBreathEffects;
    void Start()
    {
        StartCoroutine(FireBreathEffect());
        fireBreathEffects.Play();
    }

    
    private IEnumerator FireBreathEffect()
    {
        while (true)
        {
            
            if (fireBreathEffects.isPlaying)
            {
                yield return null;
                continue;
            }

            if (fireBreathEffects.isStopped)
            {
                yield return new WaitForSeconds(2f);
                fireBreathEffects.Play();
            }
        }
    }
}
