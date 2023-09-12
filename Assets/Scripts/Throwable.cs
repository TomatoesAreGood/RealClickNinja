using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEditor.Callbacks;
using UnityEditor.UI;

// using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class Throwable : MonoBehaviour
{
    public Vector3 throwVector;
    public Rigidbody2D rb;
    public GameObject prefab;

    public void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown() {
        CalculateThrowVector();
    }

    private void OnMouseDrag(){
        CalculateThrowVector();
    }
    
    private void CalculateThrowVector(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 distance = mousePos - this.transform.position;
        
        throwVector = distance*100;
    }


    private void Throw(){
        rb.AddForce(throwVector);
    }

    private void OnMouseUp(){
        Throw();
    }

    // Update is called once per frame
    private void Update(){
        if (transform.position.x < -11 || transform.position.x > 11 ){
            Instantiate(prefab).transform.position = new Vector3(0.0f,0.0f,0.0f);
            Destroy(gameObject);
        }
    }
}
