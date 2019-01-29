using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class controls : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    private float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Interable isinterable;
    private Animator animator;
    public float vida;
    public Transform Ragezoneattack;
    public float radius = 0.7f; 
    public LayerMask layerEnemy;
    private bool isPlaying = false;
    private float damage = 12;
    private float checkTime = 0.001f;
    private Vector2 oldPos;
    private bool facingright,facingup,facingleft;
    public bool Attacking;
    public int fase = 1;
    public MenuScript menuObject;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = true;
        InvokeRepeating ("PlaySound", 0.0f, 0.5f);  
        // Inicializando health bar (code Stat)
        health.Inicialize(vida,vida);


    }

    void Update()
    {
 
        // atualizando a barra de vida
        health.MyCurrentValue = vida; 
        if(vida > 0){
            //enquanto o player está vivo a movimentação é chamada
            Move();
            if(isPlaying){
                //audioSource.Play();
            }else{
                //audioSource.Stop();
            }
            isPlaying = false;
        }
        if(vida >= 100){
            vida = 100;
        }else if(vida <= 0)
        {
            // se vida chegar a zero chama função de morte
            Die();
        }
       animator.SetBool("Attacking",Attacking);// animação de ataque
    }
    void Move()
    {
        isPlaying = true;
        //Movimentação do personagem (8 direções)
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = MoveInput.normalized * speed;
        GetComponent<Animator>().SetFloat("Move",Mathf.Abs(Input.GetAxisRaw("Horizontal"))+ Mathf.Abs(Input.GetAxisRaw("Vertical")));
        GetComponent<Animator>().SetFloat("Horizontal",Input.GetAxisRaw("Horizontal"));
        GetComponent<Animator>().SetFloat("Vertical",Input.GetAxisRaw("Vertical"));
        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            if(Input.GetAxisRaw("Horizontal") == 1)
            {
                Ragezoneattack.transform.position = new Vector2(transform.position.x+0.8f,transform.position.y);
                //verificando a direção
                facingright = true;
                facingleft = false;
                facingup = false;

            }else
            {
                Ragezoneattack.transform.position = new Vector2(transform.position.x-0.8f,transform.position.y);
                facingright  = false;
                facingleft = true;
                facingup = false;
                // animator.SetBool("facingleft",facingleft);
                // animator.SetBool("facingright",facingright);
                
            }
        }
        if(Input.GetAxisRaw("Vertical")!=0)
        {
            if(Input.GetAxisRaw("Vertical") == 1)
            {
                Ragezoneattack.transform.position = new Vector2(transform.position.x,transform.position.y+0.8f);
                facingup = true;
                facingright = false;
                facingleft = false;
            }else
            {
                Ragezoneattack.transform.position = new Vector2(transform.position.x,transform.position.y-0.8f);
                facingup = false;
                facingright = false;
                facingleft = false;
            }
        }
        //atualizando a animação de parado de acordo com a direção
        animator.SetBool("facingup",facingup);
        animator.SetBool("facingright",facingright);
        animator.SetBool("facingleft",facingleft);
        speed = 10;
    }
    void FixedUpdate(){
        //função de ataque
        Attack();
        rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
    }

    void Attack()
    {
        //tecla z chama o ataque 
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attacking = true;
            animator.SetBool("Attacking",Attacking);
            //verifica todos os objetos sobre o raio de ataque com o layer Enemy
            Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(Ragezoneattack.position,radius,layerEnemy);
            for(int i = 0;i<enemiesAttack.Length;i++)
            {
                // percorre o vetor de enemys e manda o dano (o dano é descontado no script Enemycontrols)
                enemiesAttack[i].SendMessage("EnemyHit",damage);
                print("Atacou"+enemiesAttack[i].name);
            }
        }
    }
    public void Die(){
        vida = 0;
        print("MORREU");//debug
        Destroy(GetComponent<BoxCollider2D>());
        SceneManager.LoadScene("End");//chama a tela de gameover
        speed = 0;//desliga qualquer movimentação 
    }
    // get everyone
   
    void HitPlayer(float Edamage)
    {
        vida-=Edamage; // atualiza vida
    }
    void PlaySound () {
        if ((Input.GetButton("Vertical") || Input.GetButton("Horizontal")) && (GetComponent<SpriteRenderer>().enabled)){
           //audioSource.PlayOneShot(walking);
        }else{
            // audioSource.Stop();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // printa na tela o raio do ataque 
        Gizmos.DrawWireSphere(Ragezoneattack.position,radius);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.tag == "Cama"){
            if(PlayerPrefs.GetFloat("fase") == 0){
                menuObject.CallLoadSonho();
            }else if (PlayerPrefs.GetFloat("fase") == 1){
                menuObject.CallLoadSonho2();
            }else if (PlayerPrefs.GetFloat("fase") == 2){
                menuObject.CallLoadSonho3();
            }else if (PlayerPrefs.GetFloat("fase") == 3){
                menuObject.CallEnd();
            }
            
        }else if(col.collider.tag == "morte"){
            col.collider.SendMessage("Use");
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if( col.tag == "BloodOrb"){
            col.SendMessage("Use");
        }
    }
}
