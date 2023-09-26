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
        base.Start();
        GameManager.bombs.Add(this);
    }

    protected override void OnDisable(){
        base.OnDisable();
        GameManager.bombs.Remove(this);
    }
  
}