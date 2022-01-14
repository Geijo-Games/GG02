using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public bool isEnabled;
    public float SpawnSpeed;
    public float SpawnInterval;
    public int SpawnNum;
    public float SpawnEachGemOffset = 0.5f;
    public float SpawnForceOffset = 0.1f;

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
            for(int i = 0; i < SpawnNum; i++)
            {
                Vector3 pos = Vector3.zero;
                float _randomValueX = Random.Range(-SpawnEachGemOffset, SpawnEachGemOffset);
                float _randomValueY = Random.Range(-SpawnEachGemOffset, SpawnEachGemOffset);
                pos.x = _randomValueX + transform.position.x;
                pos.y = _randomValueY + transform.position.y;
                GameObject obj = GemPool.Instance.Spawn("Gem", pos, transform.rotation);
                if (obj && obj.TryGetComponent(out Rigidbody2D rigidbody))
                {
                    float _SpawnSpeed = SpawnSpeed * Random.Range(1- SpawnForceOffset, 1+ SpawnForceOffset);
                    rigidbody.AddForce(new Vector2(transform.up.x, transform.up.z) * SpawnSpeed);
                }
            }
            m_SpawnTimer = 0;
        }
    }
}
