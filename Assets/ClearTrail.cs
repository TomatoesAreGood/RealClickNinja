using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearTrail : MonoBehaviour
{
    

    private void OnEnable(){
        var trail = GetComponent<TrailRenderer>();
        trail.Clear();
        Invoke("ResetTrails", 0.01f);
    }

    private void OnDisable(){
        var trail = GetComponent<TrailRenderer>();
        trail.Clear();
        trail.time = -1;
        Invoke("ResetTrails", 0.01f);
    }
}
 
