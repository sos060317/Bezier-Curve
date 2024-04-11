using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_Classic : MonoBehaviour
{
    [Range(0f, 1f)] public float t;
    public Transform[] poses;
    public Transform targer;

    void Update()
    {
        t += Time.deltaTime * 0.1f;

        Vector3 vecPos = cubicBezierVec(poses[0].position, poses[1].position, poses[2].position, poses[3].position, t);

        targer.position = vecPos;
    }

    Vector3 cubicBezierVec(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        var ab = Vector3.Lerp(a, b, t);
        var bc = Vector3.Lerp(b, c, t);
        var cd = Vector3.Lerp(c, d, t);

        var abbc = Vector3.Lerp(ab, bc, t);
        var bccd = Vector3.Lerp(bc, cd, t);

        return Vector3.Lerp(abbc, bccd, t);
    }
}
