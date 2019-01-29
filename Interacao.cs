using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacao : MonoBehaviour,Interable
{
    [SerializeField]
    private Image barra;
    private int LootQtd;
    public bool Used = false;
    public GameObject[] Coletaveis;
    private Animator animator;
    public GameObject Player;
    //public GameController gameController;
    private Coroutine start;

    public void Start()
    {

    }
    public virtual void Interact()
    {   
   
    }

    public virtual void StopInteract()
    {
        
    }

}
