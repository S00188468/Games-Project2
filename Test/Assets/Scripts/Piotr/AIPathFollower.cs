using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathFollower : NavMeshEnemy
{
    // Start is called before the first frame update
    GuardAttack GuardAttack;
    public PathNode CurrentNode;
    AudioSource AudioSource;
    
    GuardDetection GuardDetection;
   protected Transform player;
    Transform guard;
    Vector3 lastknownposition;
    public AudioClip stoprightthere;
    bool sawplayer;
    bool lookingforplayer;
    bool playaudioondetection;
   public bool CanAttack;
    public float patrolspeed=1.5f;
    public float chasespeed=2.5f;
    float attackTimer;
    public float TimeToAttack;
    float attackdistance = 10f;
    
    public override void Start()
    {
        base.Start();        
        MoveToPathNode();
        GuardDetection = GetComponent<GuardDetection>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        guard = GameObject.FindGameObjectWithTag("Enemy").transform;
        AudioSource = GetComponent<AudioSource>();
        GuardAttack = GetComponent<GuardAttack>();
        playaudioondetection = true;


    }
   public override void Update()
    {
        base.Update();
        EngagePlayer();
    }
    private void MoveToPathNode(PathNode node)
    {
        CurrentNode = node;        
        MoveTo(CurrentNode.gameObject);
    }
   private void MoveToPathNode()
    {
        if (CurrentNode!=null)
        {
            MoveTo(CurrentNode.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pathway")&&other.gameObject.name==CurrentNode.name)
        {
            PathNode node;
            if (other.TryGetComponent<PathNode>(out node))
            {
                CurrentNode = node.NextNode;
                MoveToPathNode();
            }
        }
    }
    private void EngagePlayer()
    {
        if (GuardDetection.PlayerDetected())
        {
            
            if (playaudioondetection==true)
            {
                AudioSource.PlayOneShot(stoprightthere);
                playaudioondetection = false;
            }
            sawplayer = true;            
            navMeshAgent.speed = chasespeed;
            lastknownposition = player.position;
            
            MoveTo(player.position);
            if (Vector3.Distance(guard.position, player.position) <= attackdistance)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer>=TimeToAttack)
                {
                    StartCoroutine(GuardAttack.AttackTarget(player));
                    attackTimer = 0f;
                }
                
            }
            
        }
        else if (sawplayer&&!GuardDetection.PlayerDetected())
        {
            MoveTo(lastknownposition);
            if (Vector3.Distance(guard.position, lastknownposition) <= 1f)
            {
                playaudioondetection = true;
                sawplayer = false;
                navMeshAgent.speed = patrolspeed;
                MoveToPathNode();
            }
        }
        
        
    }
}
