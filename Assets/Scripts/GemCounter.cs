
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : MonoBehaviour
{

    //public UnityEngine.UI.Text TimeText;

    public float countTime;
    Vector3 gemscale;  //‡@‰¼‚Ì•Ï”éŒ¾
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
                gemscale = gameObject.transform.localScale; //ŸŒ»İ‚Ì‘å‚«‚³‚ğ‘ã“ü
                gemscale.x = gemscale.x + countTime / 1000;
                gemscale.y = gemscale.y + countTime / 1000;
                gameObject.transform.localScale = gemscale; //‡B‘å‚«‚³‚É•Ï”kero‚ğ‘ã“ü
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



    //OnCollisionStayŠÖ”
    private void OnCollisionStay2D(Collision2D collision)
    {

        //Sphere‚ªPlane‚ÆÕ“Ë‚µ‚Ä‚¢‚éê‡
        if (collision.gameObject.tag == "Fluid")
        {
            
            a = 1;
        }
    }

    //OnCollisionExitŠÖ”
    private void OnCollisionExit2D(Collision2D collision)
    {

        //Sphere‚ªPlane‚Æ—£‚ê‚½ê‡
        if (collision.gameObject.tag == "Fluid")
        {
            a = 2;
        }
    }





}
