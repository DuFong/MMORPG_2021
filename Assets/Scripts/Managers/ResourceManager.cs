using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject preFab = Load<GameObject>($"Prefabs/{path}");
        if(preFab == null)
        {
            Debug.Log($"Can't found Prefabs : {path}");
            return null;
        }
        return Object.Instantiate(preFab, parent);
    }

    public void Destroy(GameObject gameObject)
    {
        if(gameObject == null)
        {
            return;
        }
        Object.Destroy(gameObject);
    }
}
