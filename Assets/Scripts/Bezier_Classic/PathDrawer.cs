using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public GameObject pathPointPrefab; // 경로를 그릴 때 사용할 점 프리팹
    public float minDistance = 0.1f;   // 경로에 새로운 점을 추가할 최소 거리

    private List<Vector2> pathPoints = new List<Vector2>(); // 오브젝트가 지나간 경로의 점들

    // 새로운 경로 점 추가
    private void AddPathPoint(Vector2 newPosition)
    {
        if (pathPoints.Count == 0 || Vector2.Distance(pathPoints[pathPoints.Count - 1], newPosition) > minDistance)
        {
            pathPoints.Add(newPosition);
            Instantiate(pathPointPrefab, newPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        // 오브젝트의 현재 위치를 경로에 추가
        Vector2 currentPosition = transform.position;
        AddPathPoint(currentPosition);
    }
}
