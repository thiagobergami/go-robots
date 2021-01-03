using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField] float _maxLifeTime = 10;

    Gun _gun;
    float _disableTime;

    public void SetGun(Gun gun) => _gun = gun;
    public void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        _gun?.AddToPool(this);

        var enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            int playerNumber = _gun.GetComponent<Player>().PlayerNumber;
            enemy.TakeDamage(collision.contacts[0].point, playerNumber);
        }
    }
    void Update()
    {
        if(Time.time >= _disableTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable() => _disableTime = Time.time + _maxLifeTime;

}
