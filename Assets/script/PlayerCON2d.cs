using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCON2d : MonoBehaviour
{
    [SerializeField] int _life = 5;//���C�t
    public GameObject _bullet;//�e
    public GameObject _enemybullet;//�G�̒e

    float up = 0.2f;
    float right = 0.1f;//�E�Ɉړ��i�}�C�i�X�ɂ���΍��j

    //jumpCount
    [SerializeField] private int _jcount = 0;
    [SerializeField] private float _timer;

    // �����^�̕ϐ����g���Ă܂��B
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
        //�v���C���[�̍��E�̓���
        move["right"] = Input.GetKey(KeyCode.RightArrow);
        move["left"] = Input.GetKey(KeyCode.LeftArrow);

        if (Input.GetKeyDown(KeyCode.Space))//�W�����v
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
            //�e�𐶂ݏo��
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
        if(transform.position.x == _enemybullet.transform.position.x)//�G�̋ʂƎ����������ʒu�Ȃ�
        {
            //���C�t���P���炷
           _life= _life - 1;
            if (_life == 0)//���C�t���O�Ȃ�
            {
                //�v���C���[������
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        //�v���C���[�̍��E�̓���
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
        //�W�����v�̔���
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