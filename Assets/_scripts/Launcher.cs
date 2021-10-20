using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZGame.SDK;

public class Launcher : MonoBehaviour
{
    
    void Start()
    {
        FirebaseSdkManager.Instance.Init();
    }

    
 
}
