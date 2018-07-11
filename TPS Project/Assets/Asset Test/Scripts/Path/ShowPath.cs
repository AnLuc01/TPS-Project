using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowPath : MonoBehaviour {

    public Color32 lineColor;
    public List<Transform> Nodes = new List<Transform>();
    
     void OnDrawGizmos()
    {
        Gizmos.color = lineColor;                                           /*tutta questa funzione serve per trovare tutti i nodi, figli dell'oggetto path, ma esc ludendo*/
        Transform[] pathTransform = GetComponentsInChildren<Transform>();   /* l'oggetto padre in questo modo: si fa una lista vuota di nodi ed un array di tutti i figli, incluso*/
        Nodes = new List<Transform>();                                        /*il padre, se il transform del figlio i != transform del padre allora aggiungilo alla lista di nodi*/

        int i = 0;
        for (i = 0; i < pathTransform.Length; i++) { 
            if(pathTransform[i] != transform)
            {
                Nodes.Add(pathTransform[i]);
            }

            
        }
        i = 0;

        for(i = 0; i<Nodes.Count; i++)
        {
            Vector3 currentNode = Nodes[i].position;
            Vector3 prevNode = Vector3.zero;

            if (i > 0)
            {
                 prevNode = Nodes[i - 1].position;
            } else if(i==0 && Nodes.Count>1)
            {
                prevNode = Nodes[Nodes.Count-1].position;
            }
            Debug.DrawLine(prevNode, currentNode, Color.magenta);
        }  
        
    }
}
