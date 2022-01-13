using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public bool isEnabled;
    public Vector3 SpawnPosOffset;
    public float SpawnSpeed;
    public float SpawnInterval;

    private float m_SpawnTimer;

    void FixedUpdate()
    {
        if (isEnabled)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        m_SpawnTimer += Time.deltaTime;
        if(m_SpawnTimer > SpawnInterval)
        {
            GameObject obj = GemPool.Instance.Spawn("Gem", transform.position + SpawnPosOffset, transform.rotation);
            if (obj && obj.TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.AddForce(new Vector2(transform.up.x, transform.up.z) * SpawnSpeed);
            }
            m_SpawnTimer = 0;
        }
    }
}
