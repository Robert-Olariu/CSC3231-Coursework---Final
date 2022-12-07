using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaynightCycle : MonoBehaviour
{
    public float DaynightCycleTime;
    public float Speed;
    public float RealTime;

    void Start()
    {       
    }
    
    void Update()
    {
        RealTime = Mathf.InverseLerp(0, 360, DaynightCycleTime) * 24;
        DaynightCycleTime = DaynightCycleTime + Speed;
        transform.rotation = Quaternion.Euler(DaynightCycleTime -90,0,0);
    }
}
