using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableFruit : ThrowableObj
{
    public GameObject xMarkPrefab;
    [SerializeField] BoxCollider2D right;
    [SerializeField] BoxCollider2D left;
    [SerializeField] BoxCollider2D top;
    [SerializeField] BoxCollider2D bot;

    protected override void Start(){
        base.Start();
        Spawner.fruits.Add(this);
    }

    protected override void Update(){
        base.Update();

        if(Blade.circleCollider.IsTouching(left) || Blade.circleCollider.IsTouching(right)){
            CutHorizontally();
        }
        if(Blade.circleCollider.IsTouching(top) || Blade.circleCollider.IsTouching(bot)){
            CutVertically();
        }
        
        if (hitGround()){
            GameManager.lives--;
            Instantiate(xMarkPrefab).transform.position = new Vector2((float)gameObject.transform.position.x, -4.4f);
            Destroy(gameObject);
        }
    }

    private void CutVertically(){
        GameObject unSlicedFruit = transform.GetChild(0).gameObject;
        GameObject slicedFruit = transform.GetChild(1).gameObject;
        GameObject verticalCut = slicedFruit.transform.GetChild(1).gameObject;
        GameObject right = verticalCut.transform.GetChild(0).gameObject;
        GameObject left = verticalCut.transform.GetChild(1).gameObject;
        Rigidbody2D rightRB = right.GetComponent<Rigidbody2D>();
        Rigidbody2D leftRB = left.GetComponent<Rigidbody2D>();

        verticalCut.SetActive(true);
        unSlicedFruit.SetActive(false);
        rightRB.velocity = rb.velocity;
        rightRB.angularVelocity = rb.angularVelocity;
        leftRB.velocity = rb.velocity;
        leftRB.angularVelocity = rb.angularVelocity;

        verticalCut.transform.SetParent(null);

        rightRB.gravityScale = 5;
        leftRB.gravityScale = 5;

        Destroy(verticalCut.gameObject, 2f);
        Destroy(gameObject);
    }
    private void CutHorizontally(){
        GameObject unSlicedFruit = transform.GetChild(0).gameObject;
        GameObject slicedFruit = transform.GetChild(1).gameObject;
        GameObject horizontalCut = slicedFruit.transform.GetChild(0).gameObject;
        GameObject top = horizontalCut.transform.GetChild(0).gameObject;
        GameObject bot = horizontalCut.transform.GetChild(1).gameObject;
        Rigidbody2D topRB = top.GetComponent<Rigidbody2D>();
        Rigidbody2D botRB = bot.GetComponent<Rigidbody2D>();

        horizontalCut.SetActive(true);
        unSlicedFruit.SetActive(false);
        topRB.velocity = rb.velocity;
        topRB.angularVelocity = rb.angularVelocity;
        botRB.velocity = rb.velocity;
        botRB.angularVelocity = rb.angularVelocity;

        horizontalCut.transform.SetParent(null);

        topRB.gravityScale = 5;
        botRB.gravityScale = 5;

        Destroy(horizontalCut.gameObject, 2f);
        Destroy(gameObject);
    }
    

    protected override void OnMouseDown(){
        base.OnMouseDown();
        GameManager.score++;
    }

    protected override void OnDisable(){
        base.OnDisable();
        Spawner.fruits.Remove(this);
    }
}
