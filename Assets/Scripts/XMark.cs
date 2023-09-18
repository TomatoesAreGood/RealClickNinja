using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMark : MonoBehaviour
{
    void OnEnable(){
        Destroy(gameObject, 1f);
    }
}

