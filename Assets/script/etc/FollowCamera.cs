using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float distanceAway = 7f;
    public float distanceUp = 4f;


    // 따라다닐 객체
    public Transform follow;

    private void LateUpdate()
    {
        transform.position = follow.position + Vector3.up *
            distanceUp - Vector3.forward * distanceAway;
    }
}
