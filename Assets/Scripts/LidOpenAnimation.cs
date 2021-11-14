using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidOpenAnimation : MonoBehaviour
{
    Animator animator;
    int LidNum = 0;
    bool isRightLidOpeningWarning = false;
    bool isRightLidOpening = false;
    bool isRightLidClosingWarning = false;
    bool isRightLidClosing = false;
    bool isBottomLidOpeningWarning = false;
    bool isBottomLidOpening = false;
    bool isBottomLidClosingWarning = false;
    bool isBottomLidClosing = false;
    bool isLeftLidOpeningWarning = false;
    bool isLeftLidOpening = false;
    bool isLeftLidClosingWarning = false;
    bool isLeftLidClosing = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("LidAnimation");
    }
    IEnumerator LidAnimation()
    {
        LidNum = 1;
        animator.SetInteger("LidNumber", 1);
        Debug.Log("Yaik!");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Yaik!");
        animator.SetBool("RightLidOpeningWarning", true);
    }
}
