using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCON2d : MonoBehaviour
{
    [SerializeField] int _life = 5;//ライフ
    public GameObject _bullet;//弾
    public GameObject _enemybullet;//敵の弾

    float up = 0.2f;
    float right = 0.1f;//右に移動（マイナスにすれば左）

    //jumpCount
    [SerializeField] private int _jcount = 0;
    [SerializeField] private float _timer;

    // 辞書型の変数を使ってます。
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"right", false },
        {"left", false },
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの左右の動き
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);

        if (Input.GetKeyDown(KeyCode.Space))//ジャンプ
        {
            if (_jcount < 2)
            {
                StartCoroutine(Jump());
                _jcount++;

                if (Input.GetKeyUp(KeyCode.Space) && _jcount == 1)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        StopCoroutine(Jump());
                        StartCoroutine(Jump());
                        _jcount++;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //弾を生み出す
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
        if(transform.position.x == _enemybullet.transform.position.x)//敵の玉と自分が同じ位置なら
        {
            //ライフを１減らす
           _life= _life - 1;
            if (_life == 0)//ライフが０なら
            {
                //プレイヤーを消す
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        //プレイヤーの左右の動き
        if (move["right"])
        {
            transform.Translate(right, 0f, 0f);
        }
        if (move["left"])
        {
            transform.Translate(-right, 0f, 0f);
        }
    }

    IEnumerator Jump()
    {
        //ジャンプの判定
        for (int i = 0; i < 15; i++)
        {
            transform.Translate(0f, up, 0f);
            yield return new WaitForSeconds(_timer);
        }
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < 15; i++)
        {
            transform.Translate(0f, -up, 0f);
            yield return new WaitForSeconds(_timer);
        }

        _jcount = 0;
    }
}