using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     int damage;
    public float speed = 5;

    private void Start()
    {
        Destroy(gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void SetBulletDamage(int amount)
    {
        damage = amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            if(e!=null)
            {
                e.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
