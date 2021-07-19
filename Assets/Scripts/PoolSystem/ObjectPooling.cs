using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu("Pool/ObjectPooling")]
public class ObjectPooling 
{
    private List<PoolObject> objects;
    private Transform objectsParent;

    public void Initialize (int count, PoolObject sample, Transform objectsParent) {
        objects = new List<PoolObject>();
        this.objectsParent = objectsParent;
        for (int i = 0; i < count; i++)
        {
            AddObject(sample, objectsParent);
        }
    }

    
    public PoolObject GetObject() {
        foreach (var obj in objects.Where(obj => obj.gameObject.activeInHierarchy==false))
        {
            return obj;
        }
        AddObject(objects[0], objectsParent);
        return objects[objects.Count-1];
    }
    
    
    private void AddObject(PoolObject sample, Transform objectsParent) {
        var temp = GameObject.Instantiate(sample.gameObject);
        temp.name = sample.name;
        temp.transform.SetParent(objectsParent);
        objects.Add(temp.GetComponent<PoolObject>());
        //temp.GetComponent<Animator>()?.StartPlayback();
        temp.SetActive(false);
    }
} 
