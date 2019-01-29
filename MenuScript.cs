using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator Transition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Paunocudedalysson()
    {
        print("meucu");
        PlayerPrefs.SetFloat("fase",0);
    }
    public void CallLoadQuarto(){
        print("loadquarto");
        StartCoroutine(LoadQuarto());
    }
    public void CallLoadSonho(){
        StartCoroutine(LoadSonho());
    }
    public void CallEnd(){
        StartCoroutine(LoadEnd());
    }
    public void CallLoadSonho2(){
        StartCoroutine(LoadSonho2());
    }
    public void CallLoadSonho3(){
        StartCoroutine(LoadSonho3());
    }
    public void CallLoadMenu(){
        print("chamou");
        StartCoroutine(LoadMenu());
    }

    public void CallLoadResumo(){
        print("chamou");
        StartCoroutine(LoadResumo());
    }

    public IEnumerator LoadQuarto(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Quarto");
    }
    public IEnumerator LoadSonho(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Sonho");
    }
    public IEnumerator LoadSonho2(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Sonho2");
    }
    public IEnumerator LoadSonho3(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Sonho3");
    }
    public IEnumerator LoadMenu(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
    public IEnumerator LoadEnd(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Fim");
    }
    public IEnumerator LoadResumo(){
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Resumo");
    }
}
