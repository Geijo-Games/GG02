#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RotateTest : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GG02/Test Rotate")]
#endif
    static void TestRotate()
    {
        float torque = 10000000 * Random.value;
        Debug.Log(torque);
        //GameObject.Find("reactor").GetComponent<Rigidbody2D>().velocity = Vector2.down;
        GameObject.Find("reactor").GetComponent<Rigidbody2D>().angularVelocity = 100;
    }
}
