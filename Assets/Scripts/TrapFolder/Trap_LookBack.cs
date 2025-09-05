using System.Collections;
using UnityEngine;

public class Trap_LookBack : MonoBehaviour
{
    [SerializeField] 
    private float moveDistance;
    [SerializeField] 
    private float moveDuration;
    [SerializeField] 
    private Vector3 beginPosition;
    [SerializeField] 
    private Vector3 endPosition;
    [SerializeField] 
    private Vector3 dosPosition;
    void Start()
    {
        beginPosition = transform.position;
        dosPosition = beginPosition + Vector3.left * moveDistance;
        endPosition = beginPosition + Vector3.right * moveDistance;
        StartCoroutine(LookBackController());

    }
    

    private IEnumerator LookBackController()
    {
        while (true)
        {
            float movedTime = 0f;
            while (movedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(beginPosition, dosPosition, movedTime / moveDuration);
                movedTime += Time.deltaTime;
                yield return null;
            }

            movedTime = 0f;
            while (movedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(dosPosition, beginPosition, movedTime / moveDuration);
                movedTime += Time.deltaTime;
                yield return null;
            }
            
            movedTime = 0f;
            while (movedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(beginPosition, endPosition, movedTime / moveDuration);
                movedTime += Time.deltaTime;
                yield return null;
            }
            
            movedTime = 0f;
            while (movedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(endPosition, beginPosition, movedTime / moveDuration);
                movedTime += Time.deltaTime;
                yield return null;
            }
           
        }
    }
}
