using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLine : MonoBehaviour
{
    bool preso;

    

   

    public Transform SpawnTorri;
    public Transform PrefabBuff;

   public bool piazza = false;

    public LayerMask layer;

    
    public int numeroBuff = 0;
    public Color startColor;
    public Color mouseOverColor;
    
    public bool mouseOver = false;

    private void Update()
    {
        CercaBuffSopra();
    }

    private void OnMouseEnter()
    {
        if(!preso)
        {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);

        }
        if (!piazza )
        {
            mouseOver = true;
            GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);

        }
    }

    private void OnMouseExit()
    {
       
        
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);

        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && !preso)
        {
            Debug.Log(name);
            if(GameManager.oggettoSelezionato!=null)
            {
                
                
                Instantiate(GameManager.oggettoSelezionato, SpawnTorri.transform.position, transform.rotation);
                GameManager.DeselezioneOggetto();
                
                    

                
                
            }
        }

        if (Input.GetMouseButtonDown(0) && piazza == true)
        {
            Debug.Log(name);
            if (GameManager.buffSelezionato != null)
            {


                Instantiate(GameManager.buffSelezionato, PrefabBuff.transform.position, transform.rotation);
                GameManager.DeselezioneBuff();
                




            }
        }
    }

    void CercaBuffSopra()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), transform.up);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, 30f, layer))
        {
            piazza = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Tower"))
    //    {
    //        piazza = true;
    //    }
    //}
}
