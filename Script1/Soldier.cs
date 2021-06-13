using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{

    [SerializeField] private string soliderName; // 군인의 이름
    [SerializeField] private int hp; // 군인의 체력

    [SerializeField] private float walkSpeed; // 걷기 스피드
    [SerializeField] private float runSpeed; // 뛰기 스피드
    private float applySpeed;

    private Vector3 direction; // 방향

    //상태변수
    private bool isAction; // 행동중인지 아닌지 판별
    private bool isWalking; // 걷는지 안 걷는지 판별
    private bool isRunning; // 뛰는지 판별
    private bool isChasing; //쫓아오는지 판별
    private bool isDead; // 죽었는지 판별

    [SerializeField] private float walkTime; // 걷기 시간
    [SerializeField] private float waitTime; // 대기 시간
    [SerializeField] private float runTime; // 뛰기 시간
    private float currentTime;

    // 필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider capCol;
    NavMeshAgent nav;
    private EnemyScore enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        enemyScore = FindObjectOfType<EnemyScore>();
        nav = GetComponent<NavMeshAgent>();
        currentTime = waitTime;
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }

    private void Move()
    {
        if (isWalking || isRunning)
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
    }

    private void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), 0.01f);
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSet();
        }
    }

    private void ReSet()
    {
        isWalking = false; isRunning = false; isAction = true;
        applySpeed = walkSpeed;
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 1); // 대기, 걷기

        if (_random == 0)
            Wait();
        else if (_random == 1)
            TryWalk();
    }

    private void Wait()
    {
        currentTime = waitTime;
        Debug.Log("대기");
    }

    private void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        currentTime = walkTime;
        applySpeed = walkSpeed;
        Debug.Log("걷기");
    }

    public void Run(Vector3 _targetPos)
    {
        direction = Quaternion.LookRotation(transform.position + _targetPos).eulerAngles;
        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }

    //player를 쫓아오게 하는 함수
    public void Chase(Vector3 _targetPos)
    {
        nav.SetDestination(_targetPos);
        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;
        anim.SetBool("Running", isRunning);
    }


    public void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                Destroy(gameObject, 2f);
                return;
            }

            Chase(_targetPos);
        }
    }

    public void Dead()
    {
        isWalking = false;
        isRunning = false;
        isDead = true;
        gameObject.GetComponent<FieldOfViewAngle>().enabled = false; //FieldOfViewAngle 스크립트를 중단시킴
        anim.SetTrigger("Dead");
        enemyScore.IncreaseEnemy(); //increaseenemy 함수를 호출
    }
}
