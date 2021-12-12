using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Rotate のアクションに応じてリアクターを回転させる。
/// 回転弾力などの処理もここでする。
/// </summary>
public class ReactorRotator : MonoBehaviour
{
    /// <summary>
    /// 今の回転角度が目的回転角度 `RotationDestination` に到達したとみなせる閾値
    /// </summary>
    private static readonly float ROTATION_EPLISON = 0.1f;

    /// <summary>
    /// 回転の速度
    /// </summary>
    private static readonly float ROTATION_SPEED = 10f;

    private Rigidbody2D rb;

    /// <summary>
    /// 回転して最終的に到達する角度
    /// </summary>
    private float RotationDestination;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // TODO: 回転弾力を加える
        RotateReactor();
    }

    /// <summary>
    /// リアクターを `RotationDestination` まで回転する。
    /// 摩擦力が起きる仮の方法で実装している。瞬時に2周回ることに対応していない。
    /// </summary>
    private void RotateReactor()
    {
        float rotation = transform.localEulerAngles.z;
        float dRot = RotationDestination - rotation;
        if (180 < Mathf.Abs(dRot)) // 普通の回転方向ではなく逆に回したほうが最短距離の場合、つまり変化量が 180 より大きい場合
        {
            // 今の回転方向に応じて実際の回転方向が逆になるように調整
            if (0 < dRot) dRot -= 360;
            else dRot += 360;
        }
        if (Mathf.Abs(dRot) < ROTATION_EPLISON)
        {
            // 目的回転角度にほぼ到達したら直接到達することにする。これで微量な動きで宝石に余計な摩擦力を与えてガクガクさせてしまうことを防ぐ。
            transform.localEulerAngles = new Vector3(0, 0, RotationDestination);
            rb.angularVelocity = 0;
        }
        else rb.angularVelocity = dRot * ROTATION_SPEED;
    }

    /// <summary>
    /// プレイヤーの回転操作によって呼び出され、回転アニメーションが到達する最終的な回転角度 `RotationDestination` を記録する関数
    /// </summary>
    /// <param name="context"></param>
    public void Rotate(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // TODO: 差分を計算するため、初期回転角度をトラッキングする
        }
        else if (context.performed)
        {
            // TODO: 瞬時に2周回せるように回転角度を 360 越えても記録できるようにする
            RotationDestination = Vector2.SignedAngle(Vector2.right, context.ReadValue<Vector2>());
            if (RotationDestination < 0) RotationDestination += 360;
        }
        else if (context.canceled)
        {
            RotationDestination = 0; // TEMP: 回転弾力を実装したら削除していい
        }
    }
}
