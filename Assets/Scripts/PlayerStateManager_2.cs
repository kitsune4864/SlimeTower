using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerStateManager_2 : MonoBehaviour
{
    private MaterialBlender materialBlender;
    
    public GameObject playerObject;
    public GameObject basicController;
    public GameObject cubePuzzleController;
    public GameObject curStructObject;
    public Animator playerAnimator;
    public Transform curStructureTransform;
    public Rigidbody playerRb;
    
    public bool canSink;
    public float duration = 2f;
    public float moveSpeed = 5f;

    public Material GhostMaterial;

    public void Start()
    {
        materialBlender = new MaterialBlender(playerObject.GetComponentInChildren<Renderer>());
    }
    public void Update()
    {
        if (canSink && Input.GetKeyDown(KeyCode.Mouse0))
        {
            canSink = false;
            MoveInStructure(curStructureTransform);
        }
    }
    private async UniTask MoveInStructure(Transform targetTransform)
    {
        curStructObject = targetTransform.gameObject;
        materialBlender.BlendMaterials(GhostMaterial, 3f).Forget();
        /*playerObject.GetComponent<Collider>().enabled = false;
        playerObject.GetComponent<Rigidbody>().isKinematic = true;
        playerObject.GetComponent<Slime_Movement>().enabled = false;
        playerObject.GetComponent<Slime_Shooting>().enabled = false;
        */
        basicController.SetActive(false);
        cubePuzzleController.SetActive(true);
        playerRb.isKinematic = true;
        
        
        playerAnimator.SetTrigger("MoveInStructure");
        Vector3 startPosition = playerObject.transform.position;
        Vector3 targetPosition = targetTransform.position;
        targetPosition.y = startPosition.y + 0.5f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            playerObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime * moveSpeed;
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
        playerObject.transform.position = targetTransform.position;
    }
}
