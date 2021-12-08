using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpowner : MonoBehaviour
{
    public GameObject prefabObj;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GemSpown", 1, 5);
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GemSpown()
    {
        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
        // ゲームオブジェクトの位置を設定します。
        obj.transform.localPosition = pos;
    }
}
