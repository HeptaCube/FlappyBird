using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // meshRenderer 변수 선언, animationSpeed 변수 초기화
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // mainTextureOffset을 "x 방향"으로 "animationSpeed * Time.deltaTime" 만큼 움직임.
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed *
            Time.deltaTime, 0);
    }
}
