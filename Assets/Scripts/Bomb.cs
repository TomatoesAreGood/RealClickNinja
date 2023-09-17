using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEditor.Callbacks;
using UnityEditor.UI;

// using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : ThrowableObj{
    protected override void Start(){
        int randnum = UnityEngine.Random.Range(0, 361);
        rb.rotation = (float)randnum;

        Spawner.allObj.Add(this);
        Spawner.bombs.Add(this);
    }

    protected override void OnDisable(){
        Spawner.allObj.Remove(this);
        Spawner.bombs.Remove(this);
    }
    protected override void OnMouseDown(){
        GameManager.score = -10000;
    }
}