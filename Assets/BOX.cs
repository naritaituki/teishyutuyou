using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    float speed = 100f;
    bool isGet;
    float lifeTime = 0.5f;  // Šl“¾Œã‚Ì¶‘¶ŠÔ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Šl“¾Œã
        if (isGet)
        {
            // ‘f‘‚­‰ñ“]
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            // ¶‘¶ŠÔ‚ğŒ¸‚ç‚·
            lifeTime -= Time.deltaTime;

            // ¶‘¶ŠÔ‚ª0ˆÈ‰º‚É‚È‚Á‚½‚çÁ–Å
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        // Šl“¾‘O
        else
        {
            // ‚ä‚Á‚­‚è‰ñ“]
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        // ƒvƒŒƒCƒ„[‚ªÚG‚ÅŠl“¾”»’è
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;
            GameManagerScript.tempCoinNum++;
         
        }
    }
}
