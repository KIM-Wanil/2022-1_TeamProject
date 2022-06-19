using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Nav Mesh Agent 사용에 필요
public class BigEnemy : MonoBehaviour
{
    public GameObject Attack1;
    GameObject target;
    NavMeshAgent agent;
    Animator animator;
    public bool isChase;
    public BoxCollider meleeArea;
    public bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        Invoke("ChaseStart", 2);
    }
    // Update is called once per frame
    void Targeting()
    {
        float targetRadius = 1f;
        float targetRange = 2f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
        
        if(rayHits.Length>0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.2f);
        Attack1.SetActive(true);
        //meleeArea.enabled = true;

        yield return new WaitForSeconds(1f);
        Attack1.SetActive(false);

        yield return new WaitForSeconds(1f);
        isChase = true;
        isAttack = false;
        animator.SetBool("isAttack", false);
    }
    private void FixedUpdate()
    {
        Targeting();
    }
    void ChaseStart()
    {
        isChase = true;
        animator.SetBool("isWalk", true);
    }
    void Update()
    {
        if (isChase)
        {
            agent.destination = target.transform.position; // 쫓아갈 위치 설정
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
