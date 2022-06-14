using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float rotationSpeed = 360f; // 회전 속도 지정
    public float gravity;    // 캐릭터에게 작용하는 중력.
    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.
    Animator animator;

    //public Button gameOverText;
    //private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        //gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (MoveDir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
                    transform.forward,
                    MoveDir,
                    rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, MoveDir)
            );
                transform.LookAt(transform.position + forward);

            }
            // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다. 넣지말기 이미함
            //MoveDir = transform.TransformDirection(MoveDir);

            //스피드 증가.넣지말기

            // MoveDir *= speed;

            //캐릭터 점프
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeed;
        }

        MoveDir.y -= gravity * Time.deltaTime;




        // 캐릭터 움직임.
        controller.Move(MoveDir * Time.deltaTime);
        controller.Move(MoveDir * speed * Time.deltaTime);
        animator.SetFloat("Speed", controller.velocity.magnitude);



    }
    void OnTriggerEnter(Collider other)
    {
       
    }
}
