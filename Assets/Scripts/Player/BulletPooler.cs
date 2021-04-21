using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    [System.Serializable]    
    public class ObjectPool
    {
        public string nameOfObjPool;
        public GameObject prefab;
        public int poolSize;
    }
    //Singleton
    public static BulletPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Code
    public List<ObjectPool> poolsList;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        //Create the pool
        foreach(ObjectPool p in poolsList)
        {
            Queue<GameObject> poolObject = new Queue<GameObject>();

            //Instantiate the obj of the pool deactive
            for (int i = 0; i < p.poolSize; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);
                poolObject.Enqueue(obj);
            }

            poolDictionary.Add(p.nameOfObjPool, poolObject);
        }
    }

    //Take an obj from the pool and spawn it
    public GameObject SpawnFromPool (string nameOfObjPool, Vector2 pos, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(nameOfObjPool))
        {
            GameObject objToSpawn = poolDictionary[nameOfObjPool].Dequeue();

            objToSpawn.SetActive(true);
            objToSpawn.transform.position = pos;
            objToSpawn.transform.rotation = rotation;

            poolDictionary[nameOfObjPool].Enqueue(objToSpawn);
            return objToSpawn;
        }
        else
        {
            Debug.LogWarning("Pool with the name: " + nameOfObjPool + " does not exist.");
            return null;
        }        
    }
}
