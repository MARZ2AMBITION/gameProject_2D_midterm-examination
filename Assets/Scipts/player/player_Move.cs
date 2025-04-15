using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Move : MonoBehaviour
{
    [SerializeField] public int speed = 5; //이동속도
    [SerializeField] public int jumpforce = 500; //점프 힘
    [SerializeField] public int Player_MaxHP = 5; //플레이어 최대채력

    public int Player_HP = 0; //플레이어 현재체력
    public float Player_Attcool_Time = 0.5f; //플레이어 공격 쿨타임

    public float Player_Paring_Time = 0.5f; //플레이어 패링 타임
    public float Player_Paringcool_Time = 0.5f; //플레이어 패링 쿨타임 타임

    private Rigidbody2D rd; //점프관련
    //public Animator animator; //애니메이션
    private bool isGround = false; //점프관련
     
    [SerializeField] Transform pos; //점프관련 땅체크 엔진접근가능
    [SerializeField] float checkRadius; //점프관련 땅체크 엔진접근가능
    [SerializeField] LayerMask layerMask; //점프관련 땅체크 엔진접근가능
    private static player_Move instance;

    private void Awake()
    {
        if (instance == null) //Awake시 palyer 소환 파괴관련
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        //animator.SetBool("Move", false); //에니메이션
    }

    // Update is called once per frame
    void Update()
    {

        float direction = Input.GetAxis("Horizontal"); //간단한 이동 및 애니메이션 관리

        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
           // animator.SetBool("Move", true);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
           // animator.SetBool("Move", true);
        }
       // else
            //animator.SetBool("Move", false);

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, layerMask); //점프
        //Debug.Log("isGround: " + isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rd.AddForce(Vector3.up * jumpforce);
            //Debug.Log("점프");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // 쉬프트 누르면 구르기 구르기중에는 무적 속도증가
        {
            speed = 10;
            //Debug.Log("달리기중");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // 변경
        {
            speed = 5;
            //Debug.Log("걷는중");
        }
    }
}
