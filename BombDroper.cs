using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDroper : MonoBehaviour
    
{
    [SerializeField] Bomb _bomdPrefab;
    [SerializeField] float _delay = 5;
    [SerializeField] float _releaseVelocity = 10f;

    float _nextDropTime;
    Player _player;

    void Awake() => _player = GetComponent<Player>();    
    void Update()
    {
        if (ShouldDropBomb())
            DropBomb();
    }

    void DropBomb()
    {
        _nextDropTime = Time.time + _delay;
        Bomb bomb = Instantiate(_bomdPrefab, transform.position, transform.rotation);
        bomb.SetPlayer(_player.PlayerNumber);
        var rigibody = bomb.GetComponent<Rigidbody>();
        if (rigibody != null) {
            rigibody.velocity = transform.forward * _releaseVelocity;
        }
    }

    bool ShouldDropBomb()
    {
        if (Time.time >= _nextDropTime && Input.GetButtonDown("Bomb"))
        {
            return true;
        }
        return false;
    }

}
