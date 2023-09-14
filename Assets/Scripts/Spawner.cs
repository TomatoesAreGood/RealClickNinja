using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public static Spawner instance;
    public bool DoPersist = true;
    public GameObject ObjectPrefab;
    
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

  

    public void SpawnFruit(){
        float randNumX = UnityEngine.Random.Range(-10,11);
        Instantiate(ObjectPrefab).transform.position = new Vector3(randNumX,-5f,0f);
    }


}
