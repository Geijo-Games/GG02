using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 宝石を定義します
/// </summary>
public class GemEntity : MonoBehaviour
{
    [Header("Attributes")]
    // 宝石名
    public string Name;
    // 宝石タイプ
    public string Type;
    // 宝石レア度
    public int Rarity;
    // 宝石サイズ
    public Vector3 Size;
    // 宝石画像
    public Image GemImage;
    // 臨界熱量
    public float CriticalHeatPoint;
    // 崩壊熱量
    public float ExplodeHeatPoint;
    // 宝石を錬成するたびに獲得したスコア
    public float Score;
    // 宝石状態一覧
    public enum GemState
    {
        Idle,
        Limit,
        OverLimit,
        Destroy
    }

    // 宝石のID
    public int m_id { get; set; }
    // 現在熱量
    private float m_curHeat;
    // 現在状態
    private GemState m_state;

    // 他の宝石とぶつかる時に、合成するかどうかの処理をします。
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out GemEntity AnotherGem))
        {
            // 条件判定
            if(this.Rarity == AnotherGem.Rarity && this.m_curHeat > CriticalHeatPoint)
            {
                // 重複送信を避けるため、2つの宝石のうちより大きなidを持つ側のみが送信操作を行います。
                if (this.m_id > AnotherGem.m_id)
                {
                    // GemManagerに「宝石を合成する」のリクエストを送信します。
                    GemManager.Instance.GemSynthesizeRequest(this, AnotherGem);
                }
            }
        }
    }

    // 熱量を設定します
    public void SetHeat(float heatAmount)
    {
        m_curHeat += heatAmount;
    }

    void FixedUpdate()
    {
        if(transform.position.y < -100)
        {
            Collect();
        }
    }

    // 画面から離れて遠すぎた時に回収します
    void Collect()
    {
        GemPool.Instance.Collect(this.gameObject);
    }

}
