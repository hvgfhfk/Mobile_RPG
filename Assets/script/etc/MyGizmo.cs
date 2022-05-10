using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    void OnDrawGizoms()
    {
        // 색
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
