using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public static Spawner instance;
    public bool DoPersist = true;
    public GameObject applePrefab;

    public static List<Throwable> fruits;

    protected virtual void Awake(){
        if (instance == null){
            instance = this;
            if(DoPersist){
                DontDestroyOnLoad(gameObject);
            }
        }else{
                Destroy(this.gameObject);
            }

        fruits = new List<Throwable>();
    }

    void Update()
    {
        if (fruits.Count < 1){
            SpawnFruit();
        }
    }

    public void DestroyedFruit(){
        
    }

    public void SpawnFruit(){
        float num = UnityEngine.Random.Range(-4,5);
        Instantiate(applePrefab).transform.position = new Vector3(num,-5f,0f);
    }


}
