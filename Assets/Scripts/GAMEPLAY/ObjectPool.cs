using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size; 
    }


    #region Singleton
    public static ObjectPool PoolInstance = null;

    private void Awake()
    {
        if (PoolInstance)
        {
            Destroy(gameObject); 
        }

        else PoolInstance = this;
    }

    #endregion 

    public List<Pool> poolList;

    public static Dictionary<string, Queue<Bullet>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<Bullet>>() ;

        foreach (Pool pool in poolList)
        {
            Queue<Bullet> objectPoolQueue = new Queue<Bullet>();
            for (int i = 0 ; i < pool.size ; i++){
                GameObject obj = Instantiate(pool.prefab, Vector3.zero , pool.prefab.transform.rotation);
                obj.SetActive(false);
                Bullet bullet = obj.GetComponent<Bullet>();
                objectPoolQueue.Enqueue(bullet); 
            }
            poolDictionary.Add(pool.tag,objectPoolQueue);
        }
    }

    public Bullet SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            Bullet objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.gameObject.SetActive(false);

            objectToSpawn.gameObject.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn; 
        }
        else Debug.LogWarning("Pool with tag " + tag + "doesn't excist.");
        return null;
    }

    public void DestroyAllBullet()
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            print("i");
            for (int j = 0; j < poolList[i].size; j++) {
                Bullet objectToSpawn = poolDictionary[poolList[i].tag].Dequeue();
                objectToSpawn.gameObject.SetActive(false);
                poolDictionary[poolList[i].tag].Enqueue(objectToSpawn);
            }
        }
    }

    
}
