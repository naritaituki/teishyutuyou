using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    float speed = 100f;
    bool isGet;
    float lifeTime = 0.5f;  // 獲得後の生存時間

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 獲得後
        if (isGet)
        {
            // 素早く回転
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            // 生存時間を減らす
            lifeTime -= Time.deltaTime;

            // 生存時間が0以下になったら消滅
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        // 獲得前
        else
        {
            // ゆっくり回転
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        // プレイヤーが接触で獲得判定
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;
            GameManagerScript.tempCoinNum++;
         
        }
    }
}
