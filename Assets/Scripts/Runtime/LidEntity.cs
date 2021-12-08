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
    private float TotalTime;

    public bool IsFinish;

    void Start()
    {
        TotalTime = AnimList[AnimList.Length - 1].CallTime;
    }

    public bool ShouldChangeState(float curTime)
    {
        if(curTime >= AnimList[CurState].CallTime && !IsFinish)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ChangeState()
    {
        // The middle state
        if(CurState > 0 && CurState < AnimList.Length - 1)
        {
            AnimList[CurState - 1].animator.SetBool(AnimList[CurState - 1].CallName, false);
            AnimList[CurState].animator.SetBool(AnimList[CurState].CallName, true);
            //Debug.Log("Cap " + lidId + " : " + AnimList[CurState].CallName);
            CurState++;
        }
        // The end state
        else if(CurState == AnimList.Length - 1)
        {
            AnimList[CurState - 1].animator.SetBool(AnimList[CurState - 1].CallName, false);
            //Debug.Log("Cap " + lidId + " : Reset");
            CurState = 0;
            IsFinish = true;
            return true;
        }
        // The first state
        else
        {
            AnimList[CurState].animator.SetBool(AnimList[CurState].CallName, true);
            //Debug.Log("Cap " + lidId + " : " + AnimList[CurState].CallName);
            CurState++;
        }
        return false;
    }

    public void LidControl()
    {
        if(AnimList.Length <= 0)
        {
            return;
        }

        Reset();
        StartCoroutine(nameof(LidAnimControl));
    }

    private void Reset()
    {
        for(int i=0; i < AnimList.Length - 1; i++)
        {
            AnimList[i].animator.SetBool(AnimList[i].CallName, false);
        }
        IsFinish = false;
    }

    IEnumerator LidAnimControl()
    {
        Debug.Log("start couroutine");
        float timer = 0;
        while(timer < TotalTime + 1)
        {
            if (ShouldChangeState(timer))
            {
                ChangeState();
            }
            timer += Time.deltaTime;
            yield return null; 
        }
        yield return null;
    }

}
