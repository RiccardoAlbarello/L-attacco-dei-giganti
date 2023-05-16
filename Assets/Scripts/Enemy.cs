using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2;
    public int health = 20;
    int currentHealt;
    GridLine gl;
    // Start is called before the first frame update
    void Start()
    {
        currentHealt = health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        currentHealt -= amount;
            if (currentHealt <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Castle")
        {


            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Buff")
        {
            Destroy(col.gameObject);
            gl.numeroBuff--;
            Destroy(gameObject);

        }

       
    }
}
