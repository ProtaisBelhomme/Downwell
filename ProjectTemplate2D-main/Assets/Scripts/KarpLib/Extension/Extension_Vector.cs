using UnityEngine;


public static class Extension_Vector
{
    public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0)
    {
        return new Vector3(vector.x + x, vector.y + y, vector.z + z);
    }
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }
    public static Vector3 XY(this Vector2 vector) => new Vector3(vector.x, vector.y, 0);
    public static Vector3 XZ(this Vector2 vector) => new Vector3(vector.x, 0, vector.y);
    public static bool InRangeOf(this Vector3 current, Vector3 target, float range)
    {
        return (current - target).sqrMagnitude <= range * range;
    }

    public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0)
    {
        return new Vector2(vector2.x + x, vector2.y + y);
    }
    public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null)
    {
        return new Vector2(x ?? vector2.x, y ?? vector2.y);
    }
    public static Vector2 XY(this Vector3 vector) => new Vector2(vector.x, vector.y);
    public static Vector2 XZ(this Vector3 vector) => new Vector2(vector.x, vector.z);
    public static bool InRangeOf(this Vector2 current, Vector2 target, float range)
    {
        return (current - target).sqrMagnitude <= range * range;
    }
}
