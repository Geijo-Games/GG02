using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SameRarityGems
{
    public int Rarity;
    public GemEntity[] Gems;
}

/// <summary>
/// 宝石を総合的に管理するManagerです。
/// </summary>
public class GemManager : MonoBehaviour
{
    public static GemManager Instance;

    public SameRarityGems[] GemList;
    public int GemRarityLimit;

    public GemSpawner GemSpawner1;

    void Start()
    {
        Instance = this;
    }

    // 二つの宝石を一つに合成します。
    public void GemSynthesizeRequest(GemEntity Gem1, GemEntity Gem2)
    {
        // 中間位置を計算します。
        Vector3 midPos = (Gem1.transform.position + Gem2.transform.position) * 0.5f;
        Quaternion midRot = Gem2.transform.rotation;

        // 合成された宝石をもとに、新しい宝石を決定します。
        if (Gem1.Rarity < GemRarityLimit)
        {
            // レア度を一段階アップし、ランダムで選びます。
            int rarity = Gem1.Rarity++;
            int total = GemList[rarity].Gems.Length;
            int id = Random.Range(0, total);
            GemEntity newGem = GemList[rarity].Gems[id];
            string prefabName = newGem.Name;

            // 新しい宝石を宝石を生成します。
            GemPool.Spawn(prefabName, midPos, midRot);

            // 元の宝石を消滅します。
            GemPool.Collect(Gem1.gameObject);
            GemPool.Collect(Gem2.gameObject);
        }
    }
}
