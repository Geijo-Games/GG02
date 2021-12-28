using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidController : MonoBehaviour
{
    public static LidController Instance;

    [Header("General Settings")]
    public bool IsEnabled = true;
    public LidEntity[] LidList = new LidEntity[4];
    public int LidSize;
    public float LidSwitchInterval;
    public bool IsLidSwitched;

    private LidEntity CurrentActiveLid;
    private int CurrentLidSize;
    private float Timer;

    public bool IsLidOpening()
    {
        if(CurrentActiveLid && CurrentActiveLid.IsOpening)
        {
            return true;
        }
        return false;
    }

    void Start()
    {
        Instance = this;
        LidSize = LidList.Length;
        CurrentLidSize = LidSize;
        Timer = 0;
        InitLid();
    }

    void InitLid()
    {
        for (int i = 0; i < LidList.Length; i++)
        {
            LidList[i].lidId = i;
        }
        ControlLid();
    }

    void Update()
    {
        if (!IsEnabled || !CurrentActiveLid || LidSwitchInterval <= 0)
            return;

        if (Timer > LidSwitchInterval)
        {
            ControlLid();
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }

    void ControlLid()
    {
        LidEntity CurLid = GetSwitchedLid();
        CurLid.LidControl();
    }

    LidEntity GetSwitchedLid()
    {
        int capId = SelectLid();
        CurrentActiveLid = LidList[capId];
        return CurrentActiveLid;
    }

    // Get random lid (not same as the prev one).
    int SelectLid()
    {
        int lidId;
        if (!CurrentActiveLid)
        {
            lidId = Random.Range(0, CurrentLidSize);
        }
        else
        {
            lidId = Random.Range(0, CurrentLidSize - 1);
            if(lidId >= CurrentActiveLid.lidId)
            {
                lidId++;
            }
        }
        return lidId;
    }
}
