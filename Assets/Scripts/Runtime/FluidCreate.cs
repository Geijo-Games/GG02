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



    // Prefab�𐶐����鍂�����`���܂��B
    public float height;

    void Start()
    {

    }

    void Update()
    {
        // �t���[���J�E���g��10�̔{���̎��ɃI�u�W�F�N�g�𐶐����܂��B
        if (Time.frameCount % 20 == 0)
        {
            CreateObject();
        }
    }

    /// <Summary>
    /// Prefab����I�u�W�F�N�g�𐶐����܂��B
    /// </Summary>
    void CreateObject()
    {
        // �Q�[���I�u�W�F�N�g�𐶐����܂��B
        GameObject obj = Instantiate(prefabObj,  Vector3.zero, Quaternion.identity);



        // �Q�[���I�u�W�F�N�g�̈ʒu��ݒ肵�܂��B
        obj.transform.localPosition = new Vector3(0f, 1.0f, 0f);


    }
}