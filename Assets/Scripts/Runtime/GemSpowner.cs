using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpowner : MonoBehaviour
{
    public GameObject prefabObj;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GemSpown", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GemSpown()
    {
        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
        // �Q�[���I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
        obj.transform.localPosition = new Vector3(0f, 1.0f, 0f);
    }
}
