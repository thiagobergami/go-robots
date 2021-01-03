using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ControllerAim : MonoBehaviour {

    Player _player;

    void Awake() => _player = GetComponent<Player>();
    void Update()
    {
        
    }
}
