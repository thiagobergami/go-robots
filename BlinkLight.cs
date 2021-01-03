using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    Light _myLight;
    int _velocity = 30; 
    // Start is called before the first frame update
    void Start()
    {
        _myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _myLight.intensity = Mathf.PingPong((Time.time * _velocity), 30);
    }
}
