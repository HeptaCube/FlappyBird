using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // 속도 변수 초기화, leftEdge 변수 선언.
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1.0f;
    }

    // Vector3.left 방향으로 speed * Time.deltaTime 속도만큼 왼쪽으로 이동함.
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // x 위치가 leftEdge 보다 작으면 오브젝트를 없앰.
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
