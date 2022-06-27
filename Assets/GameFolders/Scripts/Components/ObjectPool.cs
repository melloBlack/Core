using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Pool Variables")]
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int poolSize;

    Queue<GameObject> pooledObjects;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transform);
            newObject.SetActive(false);
            pooledObjects.Enqueue(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject newObject = pooledObjects.Dequeue();
        newObject.SetActive(true);
        pooledObjects.Enqueue(newObject);
        return newObject;
    }
}
