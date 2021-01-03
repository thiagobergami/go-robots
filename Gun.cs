using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour {

    
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] GameObject _shootPrefab;
    [SerializeField] float _delay = 0.2f;
    [SerializeField] float _bulletSpeed = 5f;

    float _nextShootTime;

    Queue<Bullet> _pool = new Queue<Bullet>();
    private AudioSource _gunAudio;
    private Vector3 _shootPosition;
    private Quaternion _shootRotation;

    Player _player;
    Vector3 _direction;

    void Awake() => _player = GetComponent<Player>();

    private void OnEnable()
    {
        _gunAudio = GetComponent<AudioSource>();
    }
         
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
        {
            _direction = raycastHit.point - _shootPosition;
            _direction.Normalize();
            _direction = new Vector3(_direction.x, 0f, _direction.z);
            transform.forward = _direction;
        }

        if (CanShoot())
            Shoot();
    }    

    void Shoot()
    {
        _shootPosition = _player.ShootPoint.position;
        _shootRotation = _player.ShootPoint.rotation;

        int playerNumber = _player.PlayerNumber;

        _gunAudio.Play();
        _nextShootTime = Time.time + _delay;
        var bullet = GetBullet();
        bullet.transform.position = _shootPosition;
        bullet.transform.rotation = _shootRotation;

        Instantiate(_shootPrefab, _shootPosition, _shootRotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;

    }

    Bullet GetBullet()
    {
        if (_pool.Count > 0)
        {
            var bullet = _pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(_bulletPrefab, _shootPosition, _shootRotation);
            bullet.SetGun(this);
            return bullet;
        }
        
    }

    bool CanShoot() 
    {
        if (Time.time >= _nextShootTime && Input.GetButton("Fire1"))
        {
            return true;
        }
        return false;
    }

    internal void AddToPool(Bullet bullet)
    {
        _pool.Enqueue(bullet);
    }
}
