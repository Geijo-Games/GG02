
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : MonoBehaviour
{

    //public UnityEngine.UI.Text TimeText;

    public float countTime;
    Vector3 gemscale;  //�@���̕ϐ��錾
    private int a;

    // Start is called before the first frame update
    void Start()
    {
        countTime = 0;
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 1)
        {

            if (countTime <= 2)
            {
                countTime += Time.deltaTime;
                Debug.Log("collision");
                Debug.Log("scaling");
                gemscale = gameObject.transform.localScale; //�����݂̑傫������
                gemscale.x = gemscale.x + countTime / 1000;
                gemscale.y = gemscale.y + countTime / 1000;
                gameObject.transform.localScale = gemscale; //�B�傫���ɕϐ�kero����
            }

            if (countTime > 2.0f )
            {
                countTime = 2.0f;
            }

        }
        if (a == 2)
        {
            countTime = countTime;
        }
        if (a == 0)
        {
            countTime = 0;
        }

        //TimeText.text = countTime.ToString("F2");

    }



    //OnCollisionStay�֐�
    private void OnCollisionStay2D(Collision2D collision)
    {

        //Sphere��Plane�ƏՓ˂��Ă���ꍇ
        if (collision.gameObject.tag == "Fluid")
        {
            
            a = 1;
        }
    }

    //OnCollisionExit�֐�
    private void OnCollisionExit2D(Collision2D collision)
    {

        //Sphere��Plane�Ɨ��ꂽ�ꍇ
        if (collision.gameObject.tag == "Fluid")
        {
            a = 2;
        }
    }





}
