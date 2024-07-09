using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 플레이어 캐릭터의 Transform
    public Vector3 offset; // 카메라와 플레이어 사이의 거리

    void Update()
    {
        // 카메라의 위치를 플레이어의 위치 + 오프셋으로 설정
        transform.position = player.position + offset;
    }
}
