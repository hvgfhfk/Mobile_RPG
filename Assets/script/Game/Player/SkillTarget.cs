using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTarget : MonoBehaviour
{
    public List<Collider> targetList;

    private void Awake()
    {
        targetList = new List<Collider>();
    }

    private void Update()
    {
        for (int i = targetList.Count - 1; i >= 0; i--)
        {
            if (targetList[i] == null)
            {
                targetList.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        targetList.Add(other);
    }

    public void OnTriggerExit(Collider other)
    {

        targetList.Remove(other);

    }

}
