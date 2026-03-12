using UnityEngine;
using System.Collections;
public class DiceFaceDetector : MonoBehaviour
{
    public int GetDiceValue()
    {
        Vector3 up = transform.up;
        Vector3 right = transform.right;
        Vector3 forward = transform.forward;

        float maxDot = -1f;
        int value = 0;

        float dot;

        dot = Vector3.Dot(up, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 1; }

        dot = Vector3.Dot(-up, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 6; }

        dot = Vector3.Dot(right, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 3; }

        dot = Vector3.Dot(-right, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 4; }

        dot = Vector3.Dot(forward, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 2; }

        dot = Vector3.Dot(-forward, Vector3.up);
        if (dot > maxDot) { maxDot = dot; value = 5; }

        return value;
    }
}