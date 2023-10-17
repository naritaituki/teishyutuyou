using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCON : MonoBehaviour
{
    public GameObject _muzule;
    public GameObject _bullet;
    Vector2 _transfome;
    // Start is called before the first frame update
    void Start()
    {
        _transfome = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //‚±‚±‚Å‘Å‚¿o‚µ‚Æ‚¯‚·
        transform.Translate(0.1f, 0, 0);
        if (transform.position.x > _transfome.x + 20)
        {
          Destroy(gameObject);
        }
    }
}
