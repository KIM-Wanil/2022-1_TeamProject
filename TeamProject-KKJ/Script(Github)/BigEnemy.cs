using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI; // Nav Mesh Agent 사용에 필요
using UnityEngine.SceneManagement;
public class BigEnemy : MonoBehaviour
{
    public GameObject Attack1;
    GameObject target;
    Player player;
    NavMeshAgent agent;
    Animator animator;
    public bool isChase;
    public BoxCollider meleeArea;
    public bool isAttack;

    float attackDelay;
    float time;

    //hp
    float maxHp;
    float currentHp;

    public GameObject hpBarPrefab;
    Canvas monsterCanvas;
    public Slider enemyHpBarSlider;// slider 초기 세팅
    GameObject hpBar;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        Invoke("ChaseStart", 2);
        player = GameObject.Find("Player").GetComponent<Player>();

        time = 0;
        attackDelay = 1;
        //hp
        maxHp = 500f;
        currentHp = 500f;

        monsterCanvas = GameObject.Find("monsterCanvas").GetComponent<Canvas>();
        hpBar = Instantiate<GameObject>(hpBarPrefab, monsterCanvas.transform);
        enemyHpBarSlider = hpBar.GetComponentInChildren<Slider>();
        hpBar.SetActive(false);
        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        _hpBar.enemyTr = this.gameObject.transform;
    }
    // Update is called once per frame
    void Targeting()
    {
        time += Time.deltaTime;
        float targetRadius = 1f;
        float targetRange = 2f;
        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
        
        if(rayHits.Length>0 && !isAttack)
        {
            use();
        }
    }
    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.5f);
        isChase = true;
        isAttack = false;
        animator.SetBool("isAttack", false);
    }
    private void FixedUpdate()
    {
        Targeting();
    }

    void use()
    {
        StartCoroutine("Attack");
        StopCoroutine("Attack");
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


        enemyHpBarSlider.maxValue = maxHp;
        enemyHpBarSlider.value = currentHp;
        if (currentHp <= 0f)
        {
            player.exp += 3;
            Destroy(hpBar);
            Destroy(gameObject);
            SceneManager.LoadScene("Clear");
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
        if(other.gameObject.CompareTag("IceField"))
        {
            hpBar.SetActive(true);
            currentHp -= player.FieldDM;
        }
    }
}
