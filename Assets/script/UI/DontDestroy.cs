using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
 //   private static DontDestroy s_instance = null;

    private void Awake()
    {
        var obj = FindObjectsOfType<DontDestroy>();

        if(obj.Length <= 2)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
     //   if(s_instance)
     //   {
     //       DestroyImmediate(gameObject);
     //       return;
      //  }

       // s_instance = this;
       // DontDestroyOnLoad(gameObject.);
       // DontDestroyOnLoad(gameObject);

    }
}
