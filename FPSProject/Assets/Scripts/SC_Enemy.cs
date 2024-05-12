using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SC_Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damaged,
        Die,
        Return
    }

    public EnemyState state;
    private Vector3 OriginPosition;
    public float moveDistance = 8;

    private Transform player;

    public float findDistance = 8;
    public float attackDistance = 4;

    private float currentTime = 0;
    public float attackDelay = 3;
    public float damageDelay = 2;
    public float speed = 3;

    // HP UI
    public Slider hpUI;
     
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        OriginPosition = this.transform.position;
        if (moveDistance < findDistance)
        {
            moveDistance = findDistance;
        }
        setEnemyStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Idle)
        {
            UpdateIdie();
        }
        else if (state == EnemyState.Move)
        {
            UpdateMove();
        }
        else if (state == EnemyState.Attack)
        {
            UpdateAttack();
        }
        else if (state == EnemyState.Damaged)
        {
            // UpdateDamaged();
        }
        else if (state == EnemyState.Die)
        {
            UpdateDie();
        }
        else if (state == EnemyState.Return)
        {
            UpdateRetrun();
        }
    }

    void UpdateIdie()
    {
        float dist = Vector3.Distance(this.transform.position, player.position);

        if (dist < findDistance)
        {
            print("[Idle] State : " + state.ToString() + "change Idle -> Move");
            state = EnemyState.Move;
        }
    }

    void UpdateMove()
    {
        float distByOrigin = Vector3.Distance(this.transform.position, this.OriginPosition);
        if (distByOrigin > moveDistance)
        {
            print("[Move] State : " + state.ToString() + "change Move -> Return");
            state = EnemyState.Return;
            return;
        }

        float dist = Vector3.Distance(this.transform.position, player.position);

        if (dist < attackDistance)
        {
            print("[Move] State : " + state.ToString() + "change Move -> Attact");
            state = EnemyState.Attack;
            return;
        }

        Vector3 dir = player.position - this.transform.position;
        dir.Normalize();
        this.transform.position = this.transform.position + dir * (speed * Time.deltaTime);
    }

    void UpdateAttack()
    {
        float dist = Vector3.Distance(this.transform.position, player.position);

        if (dist > attackDistance)
        {
            state = EnemyState.Move;
            print("[Attack] State : change Attack -> Move");
            return;
        }

        currentTime += Time.deltaTime;
        if (currentTime > attackDelay)
        {
            currentTime = 0;
            print("[Attack] State : Attack player");
            // player hit
            SC_PlayerMove playermove = player.GetComponent<SC_PlayerMove>();
            playermove.OnDamaged();
        }
    }

    void UpdateDamaged()
    {
        currentTime += Time.deltaTime;

        if (currentTime > damageDelay)
        {
            currentTime = 0;
            state = EnemyState.Idle;
            print("[Damaged] : change Damaged -> Idle");
        }
    }

    void UpdateDie()
    {
        currentTime += Time.deltaTime;

        if (currentTime > 2)
        {
            this.transform.position += Vector3.down * (speed * Time.deltaTime);

            if (transform.position.y < -2)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void UpdateRetrun()
    {
        float dist = Vector3.Distance(OriginPosition, this.transform.position);

        if (dist < 0.5f)
        {
            state = EnemyState.Idle;
            print("[Return] : change Return -> Idle");
        }
        else
        {
            Vector3 dir = OriginPosition - this.transform.position;
            dir.Normalize();
            transform.position = transform.position + dir * (speed * Time.deltaTime);
        }
    }

    // status control of enemy

    public float currHP = 0;
    public float MaxHP = 3;

    void setEnemyStatus()
    {
        currHP = MaxHP;
    }

    public void onDamaged()
    {
        currHP--;

        float ratio = currHP / MaxHP;
        hpUI.value = ratio;
        
        if (this.state == EnemyState.Die)
            return;
        
        StopAllCoroutines();
        if (currHP <= 0)
        {
            state = EnemyState.Die;
            print("[Hit] State : change some -> Die");
            return;
        }
        // using normal
        state = EnemyState.Damaged;
        print("[Hit] State : change some -> Damaged");
        // using Coroutine
        StartCoroutine(DamagedProcess());
    }

    IEnumerator DamagedProcess()
    {
        yield return new WaitForSeconds(damageDelay);
        print("[DamagedProcess] awake up");
        state = EnemyState.Idle;
    }
}
