using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LidAnimData
{
    public int State;
    public string CallName;
    public float CallTime;
    public Animator animator;
}

public class LidEntity : MonoBehaviour
{
    [Header("General Settings")]
    public bool IsEnabled = true;
    public int lidId;

    [SerializeField]
    private LidAnimData[] AnimList = new LidAnimData[5];

    private int CurState = 0;

    void Start()
    {

    }

    public bool ShouldChangeState(float curTime)
    {
        return curTime > AnimList[CurState].CallTime;
    }

    public bool ChangeState()
    {
        if(CurState > 0 && CurState < AnimList.Length - 1)
        {
            AnimList[CurState - 1].animator.SetBool(AnimList[CurState - 1].CallName, false);
            AnimList[CurState].animator.SetBool(AnimList[CurState].CallName, true);
            ///Debug.Log("Cap " + lidId + " : " + AnimList[CurState].CallName);
            CurState++;
        }
        else if(CurState == AnimList.Length - 1)
        {
            AnimList[CurState - 1].animator.SetBool(AnimList[CurState - 1].CallName, false);
            ///Debug.Log("Cap " + lidId + " : Reset");
            CurState = 0;
            return true;
        }
        else
        {
            AnimList[CurState].animator.SetBool(AnimList[CurState].CallName, true);
            ///Debug.Log("Cap " + lidId + " : " + AnimList[CurState].CallName);
            CurState++;
        }
        return false;
    }

}
