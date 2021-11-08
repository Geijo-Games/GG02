using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Rotate のアクションに応じてリアクターを回転させる。
/// 回転弾力などの処理もここでする。
/// </summary>
public class ReactorRotator : MonoBehaviour
{
    private void Update()
    {
        // TODO: 回転弾力を加える
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // TODO: 差分を計算するため、初期回転角度をトラッキングする
        }
        else if (context.performed)
        {
            // TODO: 回転角度の差分によって回転
            transform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, context.ReadValue<Vector2>())); // TEMP
        }
        else if (context.canceled)
        {
            transform.localEulerAngles = Vector3.zero; // TEMP: 回転弾力を実装したら削除していい
        }
    }
}
