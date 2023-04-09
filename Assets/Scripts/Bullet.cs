using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent<EnemyMelee>(out EnemyMelee enemy))
            {
                enemy.GetDamage(damage);
                Destroy(gameObject);
            }
            else if(other.gameObject.TryGetComponent<EnemyRanged>(out EnemyRanged enemyR))
            {
                enemyR.GetDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
