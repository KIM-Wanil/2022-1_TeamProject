using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 MoveDir;
    public GameObject RetryPanel;
    Animator animator;

    //캐릭터 스펙 변수
    float speed;
    float rotationSpeed = 360f;
    float gravity;
    public float maxHp;
    public float currentHp;

    //무기 변수
    public GameObject[] Weapon;
    public bool IceRing, IceWheel, IceField, AttackBonus, HpBonus;
    public float RingDM, WheelDM, FieldDM;
    float Ringtime, Wheeltime, Fieldtime;
    float Ringdelay, Wheeldelay, Fielddelay;

    //레벨 변수
    public float exp;
    public float maxexp;
    public int level;
    public bool is_levelup;

    //업그레이드 변수
    public float DMup, Healthup;
    public bool isRingLvUp, isWheelLvUp, isFieldLvUp, isAttackBonusLvUp, isHpBonusLvUp;
    public int Ringlv, Wheellv, Fieldlv, AttackBonuslv, Hplv, MaxUpgradelv;

    public GameObject waningText;
    public bool warningOn;
    private void Awake()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        //캐릭터 스펙 변수
        speed = 5f;
        gravity = 10f;
        maxHp = 100f;
        currentHp = 100f;

        //무기 변수
        IceRing = true;
        IceWheel = false;
        IceField = false;
        AttackBonus = false;
        HpBonus = false;
 
        Ringdelay = 3.0f;
        Wheeldelay = 5.0f;
        Fielddelay = 8.0f;

        Ringtime = 0;
        Wheeltime = 0;
        Fieldtime = 0;

        RingDM = 3.0f;
        WheelDM = 5.0f;
        FieldDM = 0.5f;

        isRingLvUp = false;
        isWheelLvUp = false;
        isFieldLvUp = false;
        isAttackBonusLvUp = false;
        isHpBonusLvUp = false;

        Weapon[1].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Weapon[2].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        //업그레이드 변수
        DMup = 0;
        Healthup = 0;
        Ringlv = 1;
        Wheellv = 0;
        Fieldlv = 0;
        AttackBonuslv = 0;
        Hplv = 0;
        MaxUpgradelv = 5;

        //레벨 변수
        exp = 0;
        maxexp = 9;
        level = 1;
        is_levelup = false;

        warningOn = false;
    }
    void Update()
    {
        Move();
        Attack();
        LevelSystem();
        if (currentHp<=0f)
        {
            RetryPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(level==10 && warningOn==false)
        {
            waningText.SetActive(true);
            warningOn = true;
            Destroy(waningText, 3.0f);
        }
    }
    void Move()
    {
        if (controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
                    transform.forward,
                    MoveDir,
                    rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir));
                transform.LookAt(transform.position + forward);
            }
        }
        MoveDir.y -= gravity * Time.deltaTime;

        // 캐릭터 움직임.
        controller.Move(MoveDir * Time.deltaTime);
        controller.Move(MoveDir * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);
    }

    void Attack()
    {
        if (IceRing)
        {
            Ringtime += Time.deltaTime;

            if (Ringlv == 1)
            {
                if (Ringdelay <= Ringtime)
                {
                    Ringtime = 0;
                    GameObject ring = Instantiate(Weapon[0], transform.position, transform.rotation);
                }
            }
            else if (Ringlv == 2)
            {
                if (isRingLvUp)
                {
                    Ringdelay -= 0.5f;
                    isRingLvUp = false;
                }

                if (Ringdelay <= Ringtime)
                {
                    Ringtime = 0;
                    GameObject ring = Instantiate(Weapon[0], transform.position, transform.rotation);
                }
            }
            else if (Ringlv == 3)
            {
                if (isRingLvUp)
                {
                    Ringdelay -= 0.5f;
                    isRingLvUp = false;
                }

                if (Ringdelay <= Ringtime)
                {
                    Ringtime = 0;
                    StartCoroutine("Ringdoubleshot");
                }
            }

            else if (Ringlv == 4)
            {
                if (isRingLvUp)
                {
                    Ringdelay -= 0.5f;
                    isRingLvUp = false;
                }

                if (Ringdelay <= Ringtime)
                {
                    Ringtime = 0;
                    StartCoroutine("Ringdoubleshot");
                }
            }

            else if (Ringlv == 5)
            {
                if (isRingLvUp)
                {
                    Ringdelay -= 0.5f;
                    isRingLvUp = false;
                }

                if (Ringdelay <= Ringtime)
                {
                    Ringtime = 0;
                    StartCoroutine("Ringtripleshot");
                }
            }

        }

        if (IceWheel)
        {
            Wheeltime += Time.deltaTime;
            Vector3 wheelplusscale = new Vector3(0.7f, 0.7f, 0.7f);
            if (Wheellv == 1)
            {
                if (Wheeldelay <= Wheeltime)
                {
                    Wheeltime = 0;
                    GameObject wheel = Instantiate(Weapon[1], transform.position, transform.rotation);
                }
            }

            else if (Wheellv == 2)
            {
                if (isWheelLvUp)
                {
                    Wheeldelay -= 0.5f;
                    isWheelLvUp = false;
                }

                if (Wheeldelay <= Wheeltime)
                {
                    Wheeltime = 0;
                    GameObject wheel = Instantiate(Weapon[1], transform.position, transform.rotation);
                }
            }

            else if (Wheellv == 3)
            {
                if (isWheelLvUp)
                {
                    Wheeldelay -= 0.5f;
                    Weapon[1].transform.localScale += wheelplusscale;
                    isWheelLvUp = false;
                }

                if (Wheeldelay <= Wheeltime)
                {
                    Wheeltime = 0;
                    GameObject wheel = Instantiate(Weapon[1], transform.position, transform.rotation);
                }
            }

            else if (Wheellv == 4)
            {
                if (isWheelLvUp)
                {
                    Wheeldelay -= 0.5f;
                    isWheelLvUp = false;
                }

                if (Wheeldelay <= Wheeltime)
                {
                    Wheeltime = 0;
                    GameObject wheel = Instantiate(Weapon[1], transform.position, transform.rotation);
                }
            }

            else if (Wheellv == 5)
            {
                if (isWheelLvUp)
                {
                    Wheeldelay -= 0.5f;
                    Weapon[1].transform.localScale += wheelplusscale;
                    isWheelLvUp = false;
                }

                if (Wheeldelay <= Wheeltime)
                {
                    Wheeltime = 0;
                    GameObject wheel = Instantiate(Weapon[1], transform.position, transform.rotation);
                }
            }
        }

        if (IceField)
        {
            Fieldtime += Time.deltaTime;
            float random = Random.Range(-25.0f, 25.0f);
            Vector3 fieldtrans = new Vector3(transform.position.x + random, transform.position.y, transform.position.z + random);
            Vector3 fieldplusscale = new Vector3(0.1f, 0.0f, 0.1f);

            if (Fieldlv == 1)
            {
                if (Fielddelay <= Fieldtime)
                {
                    Fieldtime = 0;
                    GameObject field = Instantiate(Weapon[2], fieldtrans, transform.rotation);
                }
            }

            else if (Fieldlv == 2)
            {
                if (isFieldLvUp)
                {
                    Fielddelay -= 0.25f;
                    isFieldLvUp = false;
                }

                if (Fielddelay <= Fieldtime)
                {
                    Fieldtime = 0;
                    GameObject field = Instantiate(Weapon[2], fieldtrans, transform.rotation);
                }
            }

            else if (Fieldlv == 3)
            {
                if (isFieldLvUp)
                {
                    Fielddelay -= 0.25f;
                    Weapon[2].transform.localScale += fieldplusscale;
                    isFieldLvUp = false;
                }

                if (Fielddelay <= Fieldtime)
                {
                    Fieldtime = 0;
                    GameObject field = Instantiate(Weapon[2], fieldtrans, transform.rotation);
                }
            }

            else if (Fieldlv == 4)
            {
                if (isFieldLvUp)
                {
                    Fielddelay -= 0.25f;
                    isFieldLvUp = false;
                }

                if (Fielddelay <= Fieldtime)
                {
                    Fieldtime = 0;
                    GameObject field = Instantiate(Weapon[2], fieldtrans, transform.rotation);
                }
            }

            else if (Fieldlv == 5)
            {
                if (isFieldLvUp)
                {
                    Fielddelay -= 0.25f;
                    Weapon[2].transform.localScale += fieldplusscale;
                    isFieldLvUp = false;
                }

                if (Fielddelay <= Fieldtime)
                {
                    Fieldtime = 0;
                    GameObject field = Instantiate(Weapon[2], fieldtrans, transform.rotation);
                }
            }
        }

        if (AttackBonus)
        {
            if (isAttackBonusLvUp)
            {
                DMup = 3 * AttackBonuslv;
                RingDM += DMup;
                WheelDM += DMup;
                FieldDM += DMup / 3;
                isAttackBonusLvUp = false;
            }
        }

        if (HpBonus)
        {
            if (isHpBonusLvUp)
            {
                Healthup = 10 * Hplv;
                currentHp = currentHp + Healthup;
                maxHp = maxHp + Healthup;
                isHpBonusLvUp = false;
            }
        }
    }

    void LevelSystem()
    {
        if (exp == maxexp)
        {
            is_levelup = true;
            exp = 0;
            maxexp += 9;
            level += 1;
        }

        else if (exp > maxexp)
        {
            is_levelup = true;
            float extraexp = exp - maxexp;
            exp = extraexp;
            maxexp += 9;
            level += 1;
        }
    }

    IEnumerator Ringdoubleshot()
    {
        GameObject ring = Instantiate(Weapon[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        ring = Instantiate(Weapon[0], transform.position, transform.rotation);
    }

    IEnumerator Ringtripleshot()
    {
        GameObject ring = Instantiate(Weapon[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        ring = Instantiate(Weapon[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.2f);
        ring = Instantiate(Weapon[0], transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BombEnemy"))
        {
            currentHp -= 15f;
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            currentHp -= 3.0f;
        }

        if(other.gameObject.CompareTag("Health"))
        {
            currentHp += 20.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            currentHp -= 0.5f;
        }

        if(other.gameObject.CompareTag("BigEnemy"))
        {
            currentHp -= 2.0f;
        }
    }
}
