using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererSinWave : MonoBehaviour
{
    [SerializeField]
    float start = 0f;
    [SerializeField]
    float end = 5f;
    [SerializeField][Range(5, 50)]
    int points = 5;
    [SerializeField][Min(1)]
    float amplitude = 1;
    [SerializeField][Min(1)]
    float frequency = 1;

    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        Play();
    }

    void Play(){
        lineRenderer.positionCount = points;

        for(int i = 0; i < points; ++i){
            float t = (float)i / (points - 1);
            float x = Mathf.Lerp(start, end, t);
            float y = amplitude * Mathf.Sin(2 * Mathf.PI * t * frequency);

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
