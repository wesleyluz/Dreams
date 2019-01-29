using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stat : MonoBehaviour
{
    private Image content;
    private float currentFill; 
    public float MaxValue { get; set; }

    // get e set do valor atual de vida
    public float MyCurrentValue
    {
        get
        {
            return CurrentValue;
        }

        set
        {
            CurrentValue = value;
            currentFill = CurrentValue/MaxValue; // status atual da barra de vida
        }
    }

    private float CurrentValue;
    
    // Start is called before the first frame update
    void Start()
    {
        content =  GetComponent<Image>();  
    }

    // Update is called once per frame
    void Update()
    {
        content.fillAmount = currentFill; // verifica a imagem da barra  
    }
    //inicialização chamada no controls
    public void Inicialize(float CurrentValue,float MaxValue)
    {
        this.MaxValue = MaxValue;
        MyCurrentValue = CurrentValue;
    }
}
