using UnityEngine;

public static class Extension_Renderer
{
    public static void EnableZWrite(this Renderer renderer)
    {
        foreach (Material material in renderer.materials)
        {
            if (material.HasProperty("_Color"))
            {
                material.SetInt("_ZWrite", 1);
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
            }
        }
    }
    public static void DisableZWrite(this Renderer renderer)
    {
        foreach (Material material in renderer.materials)
        {
            if (material.HasProperty("_Color"))
            {
                material.SetInt("_ZWrite", 0);
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent + 100;
            }
        }
    }
}
