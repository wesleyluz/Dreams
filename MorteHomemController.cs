using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteHomemController : MonoBehaviour
{
    // Start is called before the first frame update
    public controls Player;
    public MenuScript menuObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(){
        Player.fase += 1;
        PlayerPrefs.SetFloat("fase",PlayerPrefs.GetFloat("fase") + 1f);
        if(PlayerPrefs.GetFloat("fase") == 3){
            menuObject.CallEnd();
        }else{
            menuObject.CallLoadQuarto();
        }
        
    }
}
