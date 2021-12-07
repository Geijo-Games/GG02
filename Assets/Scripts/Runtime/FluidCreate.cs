using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Prefabからオブジェクトを生成するサンプルスクリプトです。
/// </Summary>
public class FluidCreate : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;
    Vector2 pos;


    // Prefabを生成する高さを定義します。
    public float height;

    void Start()
    {
        InvokeRepeating("CreateObject", 1, 0.01f);
        pos = this.gameObject.transform.position;
    }

    void Update()
    {
        
    }

    /// <Summary>
    /// Prefabからオブジェクトを生成します。
    /// </Summary>
    void CreateObject()
    {
        // ゲームオブジェクトを生成します。
        GameObject obj = Instantiate(prefabObj,  Vector3.zero, Quaternion.identity);



        // ゲームオブジェクトの位置を設定します。
        obj.transform.localPosition = pos;


    }
}