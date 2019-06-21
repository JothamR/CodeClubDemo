using System.Collections.Generic;
using UnityEngine;

public class Pool : ScriptableObject 
{
    public GameObject Prefab;
    private Stack<GameObject> _pool = new Stack<GameObject>();

    public Pool(GameObject prefab)
    {
        Prefab = prefab;
    }

    public GameObject Spawn(Transform transform)
    {
        GameObject obj;
        if (_pool.Count == 0)
        {
            //Create from the Prefab
            obj = Instantiate(Prefab, transform.position, transform.rotation);
        }
        else
        {
            //Get from Pool
            obj = _pool.Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
        return obj;
    }


    public void Collect(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Push(obj);
    }

    public void Clear()
    {
        while (_pool.Count > 0)
        {
            var obj = _pool.Pop();
            Destroy(obj);
        }
    }

}
