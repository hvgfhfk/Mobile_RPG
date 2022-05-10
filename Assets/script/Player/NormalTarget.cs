using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour
{
    // NormalTarget 일반 공격 할 때 반경에 있는 적들의 리스트를 관리
    public List<Collider> targetList;

    private void Awake()
    {
        targetList = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        targetList.Add(other);
    }

    // 공격 반경을 벗어나면 객체 제거
    private void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);
    }
}
