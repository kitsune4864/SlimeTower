using Cysharp.Threading.Tasks;
using UnityEngine;

public class MaterialBlender
{
    private Renderer objectRenderer;

    public MaterialBlender(Renderer renderer)
    {
        objectRenderer = renderer;
    }
    
    public async UniTask BlendMaterials(Material mat2, float duration)
    {
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer가 할당되지 않았습니다!");
            return;
        }
        float elapsedTime = 0f;
        Material blendedMaterial = new Material(objectRenderer.material); // 기존 머티리얼 복사

        objectRenderer.material = blendedMaterial; // 적용

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            blendedMaterial.Lerp(objectRenderer.material, mat2, t); // Lerp로 머티리얼 속성 보간
            elapsedTime += Time.deltaTime;
        }

        objectRenderer.material = mat2; // 최종 머티리얼 적용
    }
}
