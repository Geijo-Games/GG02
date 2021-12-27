using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemRandamScatter : MonoBehaviour
{
    [SerializeField] private GameObject _blockParent;
    [SerializeField] public BoxCollider2D _blockBoxCollider;

    private const float _MIN_INTERVAL_VALUE = 0.5f;
    private const float _MAX_INTERVAL_VALUE = 1.0f;
    private const float _MIN_X_VALUE = -1.0f;
    private const float _MAX_X_VALUE = 1.0f;
    private const float _MIN_Y_VALUE = 0.5f;
    private const float _MAX_Y_VALUE = 2.0f;


    private bool _isGameStart = true;

    private bool _isSetablePositionX;
    private bool _isSetablePositionY;
   
    private int _randomNumber;
    private float _randomInterval;
    private float _randomValueX;
    private float _randomValueY;
    public GameObject prefabObj;
    Vector3 pos = Vector3.zero;
    float GemCount;

    private readonly List<Vector3> _usePositionList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //空同然だけどリスト作っとく
        foreach (Vector3 child in _blockParent.transform)
        {
            _usePositionList.Add(child);
        }

        RandomPos();
        foreach (Vector3 child in _usePositionList)
        {
            Vector3 pos = Vector3.zero;
            pos += child;
            Instantiate(prefabObj,pos , Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomPos()
    {
        for(GemCount=0; GemCount < 11; GemCount++)
        {
            _randomValueX = Random.Range(_MIN_X_VALUE, _MAX_X_VALUE);
            _randomValueY = Random.Range(_MIN_Y_VALUE, _MAX_Y_VALUE);
            //現在使用中のポジションのリストから今利用検討中のポジションが利用可能か判定
            foreach (Vector3 position in _usePositionList)
            {
                //表示位置被りがないかオブジェクトの大きさでチェック
                _isSetablePositionX =
                    Mathf.Abs(position.x - _randomValueX) > _blockBoxCollider.bounds.size.x;
                _isSetablePositionY =
                    Mathf.Abs(position.y - _randomValueY) > _blockBoxCollider.bounds.size.y;

            }

            //位置被りがどれか1つの軸で無ければ実行する
            if (_isSetablePositionX || _isSetablePositionY)
            {
                Vector3 randomPosition = new Vector3(_randomValueX, _randomValueY);



                //新しい使用中のポジションをリストに追加
                _usePositionList.Add(randomPosition);
            }
        }
    }
    
}
