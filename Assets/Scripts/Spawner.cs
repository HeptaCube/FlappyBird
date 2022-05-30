using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.8f;
    public float minHeight = -1.0f;
    public float maxHeight = 1.0f;

    // 스크립트가 활성화 됐을 때.
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // 스크립트가 비활성화 됐을 때.
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    // 주어진 프리팹을 "transform.position (위치)"에 "Quaternion.identity (그대로/회전)"에 생성함.
    // 프리팹을 랜덤한 높이에 생성함.
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
