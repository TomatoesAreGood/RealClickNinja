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

public class Fruit : ThrowableObj{

    protected override void Start(){
        int randnum = UnityEngine.Random.Range(0, 361);
        rb.rotation = (float)randnum;

        Spawner.allObj.Add(this);
        Spawner.fruits.Add(this);
    }

    protected override void Update(){
        base.Update();
        if (hitGround()){
            GameManager.lives--;
            Destroy(gameObject);
        }
    }

    protected override void OnDisable(){
        GameManager.score++;

        Spawner.allObj.Remove(this);
        Spawner.fruits.Remove(this);
    }

}