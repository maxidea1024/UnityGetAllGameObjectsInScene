using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrintAllGameObjectsInScene : MonoBehaviour
{
    void Start()
    {
        var scene = SceneManager.GetActiveScene();

        var list = new List<GameObject>();
        SceneUtil.CollectAllGameObjectInScene(scene, list);

        for (int i = 0, n = list.Count; i < n; ++i)
        {
            var go = list[i];

            Debug.LogFormat("{0:D04} : ( NamePath : \"{1}\", InstanceID : {2:X} )", i + 1, SceneUtil.GetGameObjectPath(go), go.GetInstanceID());
        }
    }
}
