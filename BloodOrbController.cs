using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOrbController : MonoBehaviour
{
    private controls Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<controls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Use(){
        Player.vida += Random.Range(5,10);
        Destroy(gameObject);
    }
}
