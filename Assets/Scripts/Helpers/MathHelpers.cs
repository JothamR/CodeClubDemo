using UnityEngine;

public static class MathHelpers
{
    public static Vector3 SetX(this Vector3 vec, float x) { vec.x = x; return vec; } //only change X
    public static Vector3 SetY(this Vector3 vec, float y) { vec.y = y; return vec; } //only change Y
    public static Vector3 SetZ(this Vector3 vec, float z) { vec.z = z; return vec; } //only change Z

    public static Vector3 AddX(this Vector3 vec, float x) { vec.x += x; return vec; } //only change X
    public static Vector3 AddY(this Vector3 vec, float y) { vec.y += y; return vec; } //only change Y
    public static Vector3 AddZ(this Vector3 vec, float z) { vec.z += z; return vec; } //only change Z

}
