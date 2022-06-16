using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Nav Mesh Agent ��뿡 �ʿ�
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
        agent.destination = target.transform.position; // �Ѿư� ��ġ ����
        //animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
