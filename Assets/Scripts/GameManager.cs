using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabTorri = new List<GameObject>();
    public static GameObject oggettoSelezionato;

    public List<GameObject> PrefabBuff = new List<GameObject>();
    public static GameObject buffSelezionato;

    public void TorreSelezionata(int id)
    {
        if(oggettoSelezionato == null)
        {
            oggettoSelezionato = prefabTorri[id];
        }
        else
        {
           oggettoSelezionato = null;
        }
    }
    public static void DeselezioneOggetto()
    {
        oggettoSelezionato = null;
    }

    public void BuffSelezionato(int id)
    {
        if (buffSelezionato == null)
        {
            buffSelezionato = PrefabBuff[id];
        }
        else
        {
            buffSelezionato = null;
        }
    }
    public static void DeselezioneBuff()
    {
        buffSelezionato = null;
    }
}
