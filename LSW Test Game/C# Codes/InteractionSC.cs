using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionSC : MonoBehaviour
{
    
   // [HideInInspector]
    public GameObject Interactor;
    public UnityEvent CalledEvent;
    public void CallEvent(GameObject Interacted)
    {
        Interactor = Interacted;
        if (Interactor != null)
        {         
            CalledEvent.Invoke();
        }        
    }
}
