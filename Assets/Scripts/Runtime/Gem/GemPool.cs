using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大量な宝石を管理するために、Object Poolを作ります。
/// </summary>
public class GemPool : MonoBehaviour
{
    public static GemPool Instance;
    public GameObject[] GemObjs;
    public int poolAmount = 10;
    public static bool lockPoolSize = false;

    private static Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
    private int curId;

    private void Awake()
    {
        Instance = this;
        curId = 0;
    }

    private void Start()
    {
        InitGems();
    }

    // 宝石の初期化を行います。
    public void InitGems()
    {
        for (int i = 0; i < GemObjs.Length; i++)
        {
            for (int j = 0; j < poolAmount; j++)
            {
                GameObject gObj = Instantiate(GemObjs[i], Vector3.zero, Quaternion.identity);
                if (gObj.TryGetComponent(out GemEntity gem))
                {
                    gem.m_id = curId;
                    curId++;
                }
                Collect(gObj);
            }
        }
    }

    // Poolから宝石を取り出します。
    public GameObject Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        string key = prefabName + "(Clone)";
        GameObject gObj;
        if (pool.ContainsKey(key) && pool[key].Count > 0)
        {
            List<GameObject> list = pool[key];
            gObj = list[0];
            list.RemoveAt(0);
            gObj.SetActive(true);
            gObj.transform.position = position;
            gObj.transform.rotation = rotation;
            return gObj;
        }
        else if(lockPoolSize == false)
        {
            gObj = Instantiate(Resources.Load(prefabName), position, rotation) as GameObject;
            return gObj;
        }
        return null;
    }

    // 宝石をPoolに戻ります。
    public GameObject Collect(GameObject gObj)
    {
        string key = gObj.name;
        if (pool.ContainsKey(key))
        {
            pool[key].Add(gObj);
        }
        else
        {
            pool[key] = new List<GameObject>() { gObj };
        }
        gObj.SetActive(false);
        return gObj;
    }

}
