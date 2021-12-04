using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidOpenOperation : MonoBehaviour
{
    //Animator animator;
    public int LidNumber = 1;
    public LeftLidAnimation leftLidAnimation;
    public RightLidAnimation rightLidAnimation;
    public BottomLidAnimation bottomLidAnimation;
    public TopLidAnimation topLidAnimation;
    public bool Endsignal=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(Endsignal == true)
        {
            LidNumber = 0;
            Endsignal = false;
            LidNumber = Random.Range(1, 5);
        }




    }
}
