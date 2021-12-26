using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemRandamScatter : MonoBehaviour
{
    [SerializeField] private GameObject _blockParent;
    [SerializeField] public BoxCollider2D _blockBoxCollider;

    private const float _MIN_INTERVAL_VALUE = 0.5f;
    private const float _MAX_INTERVAL_VALUE = 2.0f;
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

    private readonly List<Vector3> _usePositionList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //�󓯑R�����ǃ��X�g����Ƃ�
        foreach (Transform child in _blockParent.transform)
        {
            _usePositionList.Add(child.position);
        }

        DelayInitBlock();
        foreach (Transform child in _blockParent.transform)
        {
            Vector3 pos = Vector3.zero;
            child.position += pos;
            Instantiate(prefabObj,pos , Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  DelayInitBlock()
    {
        while (_isGameStart)
        {
            //�����_���Ȓl
            _randomNumber = Random.Range(0, _blockParent.transform.childCount);
            _randomInterval = Random.Range(_MIN_INTERVAL_VALUE, _MAX_INTERVAL_VALUE);
            _randomValueX = Random.Range(_MIN_X_VALUE, _MAX_X_VALUE);
            _randomValueY = Random.Range(_MIN_Y_VALUE, _MAX_Y_VALUE);
           

            //�I�΂ꂽ�u���b�N�̈ʒu
            Vector3 selectedBlockPosition =
                    _blockParent.transform.GetChild(_randomNumber).gameObject.transform.position;

            //�I�΂ꂽ�u���b�N�̈ʒu�͔�r�Ώۂ����U�폜
            _usePositionList.Remove(selectedBlockPosition);

            //���ݎg�p���̃|�W�V�����̃��X�g���獡���p�������̃|�W�V���������p�\������
            foreach (Vector3 position in _usePositionList)
            {
                //�\���ʒu��肪�Ȃ����I�u�W�F�N�g�̑傫���Ń`�F�b�N
                _isSetablePositionX =
                    Mathf.Abs(position.x - _randomValueX) > _blockBoxCollider.bounds.size.x;
                _isSetablePositionY =
                    Mathf.Abs(position.y - _randomValueY) > _blockBoxCollider.bounds.size.y;


                //���W�̂����A�S�Ă̎��Ŕ���Ă�����u���Ȃ��̂ł�蒼��
                if (!_isSetablePositionX && !_isSetablePositionY)
                {
                    _usePositionList.Add(selectedBlockPosition);
                    break;
                }
            }

            //�ʒu��肪�ǂꂩ1�̎��Ŗ�����Ύ��s����
            if (_isSetablePositionX || _isSetablePositionY )
            {
                Vector3 randomPosition = new Vector3(_randomValueX, _randomValueY);

               

                //�V�����g�p���̃|�W�V���������X�g�ɒǉ�
                _usePositionList.Add(randomPosition);
            }
        }
    }
}
