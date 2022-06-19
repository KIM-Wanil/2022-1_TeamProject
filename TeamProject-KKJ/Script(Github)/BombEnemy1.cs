using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI; // Nav Mesh Agent 사용에 필요
public class BombEnemy1 : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    Animator animator;
    Player player;

    float maxHp;
    float currentHp;
    public GameObject hpBarPrefab;
    Canvas monsterCanvas;
    public Slider enemyHpBarSlider;// slider 초기 세팅
    GameObject hpBar;
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();

        //hp
        maxHp = 9.0f;
        currentHp = 9.0f;

        monsterCanvas = GameObject.Find("monsterCanvas").GetComponent<Canvas>();
        hpBar = Instantiate<GameObject>(hpBarPrefab, monsterCanvas.transform);
        enemyHpBarSlider = hpBar.GetComponentInChildren<Slider>();
        hpBar.SetActive(false);
        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        _hpBar.enemyTr = this.gameObject.transform;
    }

    void Update()
    {
        agent.destination = target.transform.position; // 쫓아갈 위치 설정

        enemyHpBarSlider.maxValue = maxHp;
        enemyHpBarSlider.value = currentHp;
        if (currentHp <= 0f)
        {
            player.exp += 3;
            Destroy(hpBar);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IceRing"))
        {
            hpBar.SetActive(true);
            currentHp -= player.RingDM; 
        }

        if (other.gameObject.CompareTag("IceWheel"))
        {
            hpBar.SetActive(true);
            currentHp -= player.WheelDM;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("IceField"))
        {
            hpBar.SetActive(true);
            currentHp -= player.FieldDM;
        }
    }
}
