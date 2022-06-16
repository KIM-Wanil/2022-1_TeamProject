using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Nav Mesh Agent 사용에 필요
public class BombEnemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position; // 쫓아갈 위치 설정
        //animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
