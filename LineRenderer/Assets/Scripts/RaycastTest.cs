using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField]
    LineRendererAtoB visualizerLine;
    [SerializeField]
    Transform owner;

    private void Update() {
        // MainCamera 위치를 바꾸지 않았다면 중앙이 (0, 0)
        // 마우스 좌표는 좌하단이 (0, 0)이기 때문에 마우스 좌표가 중앙일 때 (0, 0)이 되도록 설정
        Vector2 target = Vector2.zero;
        target.x = Input.mousePosition.x - Screen.width * 0.5f;
        target.y = Input.mousePosition.y - Screen.height * 0.5f;

        // 광선 방향
        Vector2 direction = (target - (Vector2)owner.position).normalized;

        // owner 위치에서 direction 방향으로 광선 발사
        RaycastHit2D hit = Physics2D.Raycast(owner.position, direction, Mathf.Infinity);

        if(hit){
            visualizerLine.Play(owner.position, hit.point);
        }
        else{
            visualizerLine.Stop();
        }
    }
}
