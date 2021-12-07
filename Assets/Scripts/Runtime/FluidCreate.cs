using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Prefab����I�u�W�F�N�g�𐶐�����T���v���X�N���v�g�ł��B
/// </Summary>
public class FluidCreate : MonoBehaviour
{
    // �I�u�W�F�N�g�𐶐����錳�ƂȂ�Prefab�ւ̎Q�Ƃ�ێ����܂��B
    public GameObject prefabObj;
    Vector2 pos;


    // Prefab�𐶐����鍂�����`���܂��B
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
    /// Prefab����I�u�W�F�N�g�𐶐����܂��B
    /// </Summary>
    void CreateObject()
    {
        // �Q�[���I�u�W�F�N�g�𐶐����܂��B
        GameObject obj = Instantiate(prefabObj,  Vector3.zero, Quaternion.identity);



        // �Q�[���I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
        obj.transform.localPosition = pos;


    }
}