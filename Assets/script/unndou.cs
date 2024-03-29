using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アタッチしたGameObjectにCharacterControllerがアタッチされていない場合、アタッチする
[RequireComponent(typeof(CharacterController))]

public class unndou : MonoBehaviour
{
    bool _isgole = false;
    // アタッチしているGameObjectのCharacterControllerを格納する変数
    private CharacterController _characterController;
    //Vector3の設定
    Vector3 _movedir = Vector3.zero;
    //自分のいるラインを格納する変数
    private int _lane;

    // X軸のスピードを設定（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float _speedX = 1.0f;
    // Z軸のスピードを設定（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float _speedZ = 1.0f;
    // 速度上昇値（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float _acceleratorZ = 0.1f;

    // 重力を設定（Inspectorタブからも値を変更できるようにする）
    [SerializeField]
    private float _gravity = 10f;

    //キャラ移動
    public static bool _stop;

    // Start is called before the first frame update
    void Start()
    {
        // アタッチしているGameObjectのCharacterControllerを取得
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_isgole)
        {
            _stop = true;
        }
        if (!_stop)
        {
            // 左右とSpaceのキーの動作
            //上限と下限を決めておくことによりそれ以上左右に動かなくさせている
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                if (_lane < 1f)
                {
                    _lane++;
                }
            }

            if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                if (_lane > -1f)
                {
                    _lane--;
                }
            }

            //Mathf.Clamp関数は、第一引数の値を、第二引数と第三引数の間で収まるようにする処理。これにより徐々に加速し最高速度を超えないようにしている
            _movedir.z = Mathf.Clamp(_movedir.z + (_acceleratorZ * Time.deltaTime), 0, _speedZ);

            float _ratioX = (_lane * 2.0f - transform.position.x) / 1.0f;
            _movedir.x = _ratioX * _speedX;
            //重力の追加
            _movedir.y -= _gravity * Time.deltaTime;

            Vector3 _globalgir = transform.TransformDirection(_movedir);
            _characterController.Move(_globalgir * Time.deltaTime);
        }

        if (_characterController.isGrounded)
        {
            _movedir.y = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gole")
        {
            _isgole = true;
        }
    }
}