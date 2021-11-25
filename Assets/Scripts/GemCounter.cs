
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : MonoBehaviour
{

    //public UnityEngine.UI.Text TimeText;

    public float countTime;
    Vector3 gemscale;  //�@仮の変数宣言
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
                //Debug.Log("collision");
                //Debug.Log("scaling");
                gemscale = gameObject.transform.localScale; //◆現在の大きさを代入
                gemscale.x = gemscale.x + countTime / 1000;
                gemscale.y = gemscale.y + countTime / 1000;
                gameObject.transform.localScale = gemscale; //�B大きさに変数keroを代入
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



    //OnCollisionStay関数
    private void OnCollisionStay2D(Collision2D collision)
    {

        //SphereがPlaneと衝突している場合
        if (collision.gameObject.tag == "Fluid")
        {
            
            a = 1;
        }
    }

    //OnCollisionExit関数
    private void OnCollisionExit2D(Collision2D collision)
    {

        //SphereがPlaneと離れた場合
        if (collision.gameObject.tag == "Fluid")
        {
            a = 2;
        }
    }





}
