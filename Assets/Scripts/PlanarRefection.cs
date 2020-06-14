using UnityEngine;
using UnityEngine.Rendering;

public class PlanarReflection : MonoBehaviour
{
    private Camera reflectionCamera;
    private RenderTexture rt;

    void OnWillRenderObject()
    {
        var cam = Camera.main;
        if (!cam)
            return;

        if (reflectionCamera)
        {
            // <- reflection camera ->
            var reflectionPosition = cam.transform.position;
            var reflectionRotation = cam.transform.rotation.eulerAngles;
            var delta = (reflectionPosition.y - transform.position.y) * 2f;
            reflectionPosition.y -= delta;
            reflectionRotation.x *= -1f;
            reflectionRotation.z *= -1f;
            reflectionCamera.transform.position = reflectionPosition;
            reflectionCamera.transform.rotation = Quaternion.Euler(reflectionRotation);

            rt = RenderTexture.GetTemporary(128, 128, 0, RenderTextureFormat.Default);
            reflectionCamera.targetTexture = rt;
            Shader.SetGlobalTexture("_ReflectionTex", rt);

            RenderTexture.ReleaseTemporary(rt);
            reflectionCamera.Render();
        }
        else
        {
            var go = new GameObject("Reflection Camera - " + cam.name);
            reflectionCamera = go.AddComponent<Camera>();
            reflectionCamera.CopyFrom(cam);
            reflectionCamera.allowMSAA = false;
            reflectionCamera.clearFlags = CameraClearFlags.Color;
            reflectionCamera.backgroundColor = Color.clear;
            reflectionCamera.cullingMask = 1 << 9;
            reflectionCamera.enabled = false;
        }
    }
}