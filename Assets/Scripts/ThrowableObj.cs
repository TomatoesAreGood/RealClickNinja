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
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class ThrowableObj : MonoBehaviour{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public new CircleCollider2D collider;


    protected void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
    }

    protected virtual void Start(){
        int randnum = UnityEngine.Random.Range(0, 361);
        rb.rotation = (float)randnum;

        Spawner.allObj.Add(this);
    }

    protected virtual void OnDisable(){
        Spawner.allObj.Remove(this);
    }

    protected virtual void OnMouseDown(){
        Destroy(gameObject);
    }
    
    protected Boolean hitGround(){
        return transform.position.y < -5.5;
    }
    
    protected virtual void Update(){
        if (hitGround()){
            Destroy(gameObject);
        }
    }

}
