using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float _countdownTime = 3f;
    [SerializeField] float _radius = 5f;
    [SerializeField] int _damage = 5;

    float _explodeTime;
    int _playerNumber;

    public void SetPlayer(int playerNumber) => _playerNumber = playerNumber;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _explodeTime = Time.time + _countdownTime;
        while (Time.time < _explodeTime) {

            yield return null;
            float randomRed = Random.Range(0, 255);
            Color newColor = new Color(randomRed, 0, 0);
            GetComponent<Renderer>().material.color = newColor;

        }
        //Do Damage
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<Enemy>();
            if(enemy)
                enemy.TakeDamage(enemy.transform.position, _playerNumber, _damage);
        }

        Destroy(gameObject);
    }
   
}
