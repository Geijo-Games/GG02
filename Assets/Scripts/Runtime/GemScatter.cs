using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScatter : MonoBehaviour
{
    public GameObject prefabObj;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        GemSpown();
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GemSpown()
    {
        GameObject obj = Instantiate(prefabObj, pos, Quaternion.identity);
        // ゲームオブジェクトの位置を設定します。
       // prefabObj.transform.localPosition = pos;

    }
}
