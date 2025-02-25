using UnityEngine;

public class Slime_Shooting : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private LayerMask WallLayer;
    [SerializeField]
    private GameObject slimeBLock;
    [SerializeField]
    private GameObject slimePiece;
    
    void Start()
    {
        WallLayer = LayerMask.GetMask("Wall");
        camera = Camera.main;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SummonSlimeBLock();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ShotSlimePiece();
        }
    }

    private void SummonSlimeBLock()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, WallLayer))
        {
            Destroy(hit.collider.gameObject);
            Vector3 pos = hit.collider.gameObject.transform.position;
            Instantiate(slimeBLock, pos, Quaternion.identity);
        }
    }

    private void ShotSlimePiece()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, WallLayer))
        {
            Vector3 throwDir = camera.transform.forward + Vector3.up;
            Instantiate(slimePiece, throwDir, Quaternion.identity);
        }
    }
}
