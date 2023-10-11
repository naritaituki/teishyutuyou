using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    float speed = 100f;
    bool isGet;
    float lifeTime = 0.5f;  // �l����̐�������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �l����
        if (isGet)
        {
            // �f������]
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            // �������Ԃ����炷
            lifeTime -= Time.deltaTime;

            // �������Ԃ�0�ȉ��ɂȂ��������
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        // �l���O
        else
        {
            // ��������]
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        // �v���C���[���ڐG�Ŋl������
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;
            GameManagerScript.tempCoinNum++;
         
        }
    }
}
