using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle : MonoBehaviour
{

    public int health = 10;
    [SerializeField] MenuManager mm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <=0)
        {
            mm.GameOver();
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health--;
        }
    }
}
