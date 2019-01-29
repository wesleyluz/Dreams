using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform zone;
    public Transform[] PatrolPoints;
    private int RandomSpot;
    private float waitTime;
    public float startWaitTime;
    public float radiusz;
    private bool viuPlayer;
    public LayerMask player;
    public float speed = 5f;
    private Vector2 direction;
    public GameObject playerobj;
    [SerializeField]
    private Stat health;
    public float vida;
    public bool Vivo = true;
    public bool Attacking;
    public float damage= 3f;
    private float cooldown = 1f;
    private int attackcount =1;

    public GameObject vidaOrb;
    void Start()
    {
        health.Inicialize(vida,vida);
        waitTime = startWaitTime;
        RandomSpot = Random.Range(0, PatrolPoints.Length);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //print(viuPlayer);
        health.MyCurrentValue = vida;
        Morreu();
        viuPlayer =  Physics2D.OverlapCircle(zone.position,radiusz,player); //detecta a entrada do player no raio de visão
        if(viuPlayer)
        {
           chasePlayer(); // função de caça ao player, sempre que ele entra no raio de visão 
           print("viu");
            if(attackcount >0){
                Attack(); // ataque do enemy
                attackcount--;
                //print(attackcount);
            }else if(attackcount == 0)
            {
                AttackCoolDown(); // função cooldown para o enemy não atacar sempre
            }
        }else
        {   
            //movimentação do enemy em um percurso pré determinado mas de forma aleatória 
            direction = (transform.position-PatrolPoints[RandomSpot].position);
            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[RandomSpot].position, speed * Time.deltaTime);
            if(waitTime <= 0){
                int AuxRandomSpot = RandomSpot; 
                RandomSpot = Random.Range(0, PatrolPoints.Length);
            if(RandomSpot == AuxRandomSpot){
                RandomSpot = Random.Range(0, PatrolPoints.Length);
            }
                waitTime = startWaitTime;
            }else{
                waitTime -= Time.deltaTime; 
                //speed = 0;
            }
        }
    }


    public void Morreu()
    {
        if(vida <=0)
        {
            Vivo =false;
        }
        if(!Vivo)
        {
            if(Random.Range(1,2) == 1){
                Instantiate(vidaOrb,transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void Attack(){
        Attacking = true;
        Collider2D ataque = Physics2D.OverlapCircle(zone.position,radiusz,player);
        ataque.SendMessage("HitPlayer",damage);
    }
    public void chasePlayer()
    {   
        waitTime = 0;
        if(Vector2.Distance(transform.position,playerobj.GetComponent<Rigidbody2D>().position) < 4){    
            Vector2 target = playerobj.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
    void AttackCoolDown()
    {   
        if(attackcount == 0)
        {   
            Attacking = false;
            cooldown-=Time.deltaTime;
            if(cooldown <=0)
            {
                attackcount = 2;
                cooldown = 1f;
            }
        }
    }
    void EnemyHit(float dano)
    {
        vida -= dano;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(zone.position,radiusz);
    }
}   

