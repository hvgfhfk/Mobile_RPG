using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private float distanceAway = 7f;
    [SerializeField]
    private float distanceUp = 7.5f;


    // 따라다닐 객체
    public Transform follow;

    private void LateUpdate()
    {
        transform.position = follow.position + Vector3.up *
            distanceUp - Vector3.forward * distanceAway;
    }
}
