using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public GameObject pathPointPrefab; // ��θ� �׸� �� ����� �� ������
    public float minDistance = 0.1f;   // ��ο� ���ο� ���� �߰��� �ּ� �Ÿ�

    private List<Vector2> pathPoints = new List<Vector2>(); // ������Ʈ�� ������ ����� ����

    // ���ο� ��� �� �߰�
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
        // ������Ʈ�� ���� ��ġ�� ��ο� �߰�
        Vector2 currentPosition = transform.position;
        AddPathPoint(currentPosition);
    }
}
