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



    // Prefabを生成する高さを定義します。
    public float height;

    void Start()
    {

    }

    void Update()
    {
        // フレームカウントが10の倍数の時にオブジェクトを生成します。
        if (Time.frameCount % 20 == 0)
        {
            CreateObject();
        }
    }

    /// <Summary>
    /// Prefabからオブジェクトを生成します。
    /// </Summary>
    void CreateObject()
    {
        // ゲームオブジェクトを生成します。
        GameObject obj = Instantiate(prefabObj,  Vector3.zero, Quaternion.identity);



        // ゲームオブジェクトの位置を設定します。
        obj.transform.localPosition = new Vector3(0f, 1.0f, 0f);


    }
}