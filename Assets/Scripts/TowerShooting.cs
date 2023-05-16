using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public int damage;
    public float shootDelay;
    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;

    public bool puoSparare;

    public LayerMask layer;
    public LayerMask layerSu;
    public LayerMask layerGiu;

    public LayerMask layerShootingSpeed;
    public LayerMask layerShootingDamage;
    public LayerMask layerShootingRange;

    public float range = 20f;

    

    

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        CercaBuffSopra();
        CercaBuffSotto();
    }

    IEnumerator Shoot()
    {
        float delay = 0;
        while(true)
        {
            Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), transform.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit, range, layer))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    puoSparare = true;
                    Debug.Log("PuoSparare");
                }
                
            }
            else
            {
                puoSparare = false;
                Debug.Log("NonPuoSparare");


            }
            if (puoSparare)
                {
                    delay += Time.deltaTime;
                    if (delay >= shootDelay)
                    {
                        foreach (var sp in bulletSpawns)
                        {
                            GameObject newBullet = Instantiate(bulletPrefab, sp.position, sp.rotation);
                            newBullet.GetComponent<Bullet>().SetBulletDamage(damage);
                        }
                        delay = 0;
                    }
                }
                    yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
        }

       
    }

    void CercaBuffSopra()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), transform.up);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, 30f, layerShootingSpeed))
        {

            if(shootDelay == 3)
            {
                shootDelay = 1.5f;

            }

            if (shootDelay == 4)
            {
                shootDelay = 3f;

            }


        }

        if (Physics.Raycast(ray, out hit, 30f, layerShootingDamage))
        {
            if(damage == 10)
            {
                damage = 15;
            }
            if (damage == 20)
            {
                damage = 40;
            }



        }
        if (Physics.Raycast(ray, out hit, 30f, layerShootingRange))
        {
            if (range == 20)
            {
                range = 35;
            }
            if (range == 15)
            {
                range = 25;
            }



        }







    }

    void CercaBuffSotto()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), -transform.up);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, 30f, layerShootingSpeed))
        {

            if (shootDelay == 3)
            {
                shootDelay = 1.5f;

            }

            if (shootDelay == 4)
            {
                shootDelay = 3f;

            }


        }
        if (Physics.Raycast(ray, out hit, 30f, layerShootingDamage))
        {
            if (damage == 10)
            {
                damage = 15;
            }
            if (damage == 20)
            {
                damage = 40;
            }



        }

        if (Physics.Raycast(ray, out hit, 30f, layerShootingRange))
        {
            if (range == 20)
            {
                range = 35;
            }
            if (range == 15)
            {
                range = 25;
            }



        }


    }




}
