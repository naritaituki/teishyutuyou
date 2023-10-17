using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCON : MonoBehaviour
{
    public GameObject _player;
    public GameObject _enemybullet;
    [SerializeField] float _range = 5;
    [SerializeField] float _revarcerange = 0;
    [SerializeField] float _time = 1;
    [SerializeField] int _life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_player.transform.position.x > _range && _player.transform.position.x <_revarcerange)
        {
            if (_time > 0)
            {
                Instantiate(_enemybullet, transform.position, Quaternion.identity);
                _time = 0;
            }
        }
    }
}
