using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScatter : MonoBehaviour
{
    public GameObject prefabObj;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
        GemSpown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GemSpown()
    {
        Instantiate(prefabObj, pos, Quaternion.identity);
        // �Q�[���I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
       // prefabObj.transform.localPosition = pos;

    }
}
