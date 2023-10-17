using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCON : MonoBehaviour
{
    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.1f, 0, 0);
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
        if(transform.position.x == _player.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
