using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3[] poses = new Vector3[4];

    float timer;
    float duration;

    void Update()
    {
        BulletShooting();
    }

    public void InitBullet(Vector3 startPos, Vector3 curvePos_01, Vector3 curvePos_02, Vector3 endPos, float _duration)
    {
        poses[0] = startPos;
        poses[1] = curvePos_01;
        poses[2] = curvePos_02;
        poses[3] = endPos;

        duration = _duration;
    }

    void BulletShooting()
    {
        if (timer > duration)
        {
            Destroy(gameObject);
            timer = 0;
        }
        timer += Time.deltaTime;
        float t = timer / duration;

        Vector3 vecPos = cubicBezierVec(poses[0], poses[1], poses[2], poses[3], t);
        Vector3 nextPos = cubicBezierVec(poses[0], poses[1], poses[2], poses[3], (timer + Time.deltaTime) / duration);

        var nextRot = nextPos - vecPos;
        var nextRotDeg = Mathf.Atan2(nextRot.y, nextRot.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, nextRotDeg);

        transform.position = vecPos;
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
