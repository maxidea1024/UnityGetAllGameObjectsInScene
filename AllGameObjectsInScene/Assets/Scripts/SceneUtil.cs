using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtil
{
    public static int CollectAllGameObjectInScene(Scene scene, List<GameObject> outGameObjects)
    {
        outGameObjects.Clear(); // just in time

        var rootGameObjects = new List<GameObject>();
        scene.GetRootGameObjects(rootGameObjects);
        
        for (int i = 0, n = rootGameObjects.Count; i < n; ++i)
        {
            CollectChildren(rootGameObjects[i].transform, outGameObjects);
        }
        
        return outGameObjects.Count;
    }

    private static void CollectChildren(Transform parent, List<GameObject> list)
    {
        list.Add(parent.gameObject);

        for (int i = 0, n = parent.childCount; i < n; ++i)
        {
            CollectChildren(parent.GetChild(i), list);
        }
    }

    public static string GetGameObjectPath(GameObject go)
    {
        string path = go.name;

        Transform node = go.transform.parent;
        while (node != null)
        {
            path = node.gameObject.name + "/" + path;
            node = node.parent;
        }

        path = "/" + path;

        return path;
    }
}
