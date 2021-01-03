using Assets.Scripts;
//using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _hitPrefab;
    [SerializeField] GameObject _hitDie;
    [SerializeField] int _health = 3;
    [SerializeField] int _pointValue = 100;

    [SerializeField] float _velocity;

    public float volume = 1;

    private AudioSource _dieAudio;
    int _currentHealth;

    private void OnEnable()
    {

        _dieAudio = GetComponent<AudioSource>();
        _currentHealth = _health;
        GetComponent<NavMeshAgent>().speed = _velocity;
    }
    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Player>();
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

    }

    public void TakeDamage(Vector3 impactPoint, int playerNumber, int amount = 1)
    {
        _currentHealth -= amount;
        Instantiate(_hitPrefab, impactPoint, transform.rotation);

        if (_currentHealth <= 0)
        {
            _dieAudio.Play();

            Instantiate(_hitDie, impactPoint, transform.rotation);

            gameObject.SetActive(false);

            ScoreSystem.Add(_pointValue, playerNumber);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player != null)
        {

            SceneManager.LoadScene(0);
        }
    }
}
