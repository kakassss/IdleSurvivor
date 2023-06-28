using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager<T> : MonoBehaviour where T : Component
{
    private Queue<T> objectPool;
    public T prefab;
    public int initialPoolSize = 10;
    public Transform parentTransform;

    protected virtual void Awake()
    {
        objectPool = new Queue<T>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            T obj = Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            obj.name = "pistolBullet " + i.ToString();
            objectPool.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (objectPool.Count > 0)
        {
            T obj = objectPool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(true);
            return obj;
        }
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.rotation = Quaternion.identity;
        obj.transform.position = Vector3.zero;
        objectPool.Enqueue(obj);
    }
}
