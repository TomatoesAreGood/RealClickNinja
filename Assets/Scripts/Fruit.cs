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
    public GameObject xMarkPrefab;

    protected override void Start(){
        base.Start();
        GameManager.fruits.Add(this);
    }

    protected override void Update(){
        base.Update();
        if (hitGround()){
            GameManager.lives--;
            Instantiate(xMarkPrefab).transform.position = new Vector2((float)gameObject.transform.position.x, -4.4f);
            Destroy(gameObject);
        }
    }

    protected override void OnMouseDown(){
        base.OnMouseDown();
        GameManager.score++;
    }

    protected override void OnDisable(){
        base.OnDisable();
        GameManager.fruits.Remove(this);
    }
}