using UnityEngine;

public static class Bezier
{
    public static Vector2 GetPoint(Transform maxPoint, Transform midUpperPoint, Transform midLowerPoint, Transform minPoint, float interpolationRatio)
    {
        Vector2 point01 = Vector2.Lerp(maxPoint.position, midUpperPoint.position, interpolationRatio);
        Vector2 point12 = Vector2.Lerp(midUpperPoint.position, midLowerPoint.position, interpolationRatio);
        Vector2 point23 = Vector2.Lerp(midLowerPoint.position, minPoint.position, interpolationRatio);

        Vector2 point012 = Vector2.Lerp(point01, point12, interpolationRatio);
        Vector2 point123 = Vector2.Lerp(point12, point23, interpolationRatio);

        return Vector2.Lerp(point012, point123, interpolationRatio);
    }
}