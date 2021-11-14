using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollider : MonoBehaviour
{
    // Start is called before the first frame update
    int gem_counter = 0;
    int gem_heat = 0;
    float countTime = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gem_counter);
        
        while (gem_counter == 1&&gem_heat<1000)
        {
            gem_heat += 1;
            // countTime‚ÉAƒQ[ƒ€‚ªŠJŽn‚µ‚Ä‚©‚ç‚Ì•b”‚ðŠi”[
            countTime += Time.deltaTime;

            // ¬”2Œ…‚É‚µ‚Ä•\Ž¦
           // GetComponent<Text>().text = countTime.ToString("F2");
            Debug.Log(gem_heat);
            if (gem_heat>10001)
            {
                break;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fluid")
        {

            
            gem_counter = 1;


        }
        else
        {
            gem_counter = 0;
        }
    }
}