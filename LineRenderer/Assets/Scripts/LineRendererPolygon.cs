using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererPolygon : MonoBehaviour
{
    [SerializeField][Range(3, 100)]
    int polygonPoints = 3;
    [SerializeField]
    float radius = 3f;

    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = true;
    }

    private void Update() {
        Play();
    }

    void Play(){
        lineRenderer.positionCount = polygonPoints;

        float anglePerStep = 2 * Mathf.PI / polygonPoints;

        for(int i = 0; i < polygonPoints; ++i){
            Vector2 point = Vector2.zero;
            float angle = anglePerStep * i;

            point.x = Mathf.Cos(angle) * radius;
            point.y = Mathf.Sin(angle) * radius;

            lineRenderer.SetPosition(i, point);
        }
    }
}
