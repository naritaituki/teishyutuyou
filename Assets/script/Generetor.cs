using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generetor : MonoBehaviour
{
    // [SerializeField] GameObject _box;
    public GameObject _box;
    public float s_distance;
    public float g_distance;
    
    // Start is called before the first frame update
    void Start()
    {
        for (float i = s_distance; i < g_distance; i = i + 5)
        {
            Instantiate(_box, new Vector3(0f,1f,i), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
