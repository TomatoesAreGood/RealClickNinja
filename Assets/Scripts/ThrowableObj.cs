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
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D collider;
 

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
        return transform.position.y < -6.5;
    }
    
    protected void Spin(){
        float angle = this.transform.localRotation.eulerAngles.z;
        this.transform.localRotation = Quaternion.Euler(0f, 0f, angle + Spawner.spinSpeed* Time.deltaTime);
    }

    protected virtual void Update(){
       Spin();
        if (hitGround()){
            Destroy(gameObject);
        }
    }

}
