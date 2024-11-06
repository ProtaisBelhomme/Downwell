using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Extension_Camera
{
    public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null)
    {
        Vector2 margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

        Vector2 result;
        float halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
        result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
        result.x = result.y * camera.aspect + margin.x;
        result.y += margin.y;
        return result;
    }
}
