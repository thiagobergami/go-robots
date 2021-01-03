using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed = 1f;
    [SerializeField] Transform _direction;
    [SerializeField] Transform _shootPoint;
    [SerializeField] int _playerNumber = 1;

    public Transform ShootPoint =>  _shootPoint;

    public int PlayerNumber => _playerNumber;

    private Animator _animator;
    private Vector3 _newDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveWithController();        
        
    }

    void MoveWithController()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * Time.deltaTime * _speed, _direction);
        _animator.SetBool("Run", movement.magnitude > 0);
    }

    void AimWithController()
    {
        float horizontalAim = Input.GetAxis("HorizontalAim");
        float verticalAim = Input.GetAxis("VerticalAim");

        if (horizontalAim != 0 && verticalAim != 0)
        {
            transform.forward = new Vector3(horizontalAim, 0f, verticalAim);
        }
       
    }
}
