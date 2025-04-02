using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Move : MonoBehaviour
{
    [SerializeField] public int speed = 5; //�̵��ӵ�
    [SerializeField] public int jumpforce = 500; //���� ��
    [SerializeField] public int Player_MaxHP = 5; //�÷��̾� �ִ�ä��

    public int Player_HP = 0; //�÷��̾� ����ü��
    public float Player_Attcool_Time = 0.5f; //�÷��̾� ���� ��Ÿ��

    public float Player_Paring_Time = 0.5f; //�÷��̾� �и� Ÿ��
    public float Player_Paringcool_Time = 0.5f; //�÷��̾� �и� ��Ÿ�� Ÿ��

    private Rigidbody2D rd; //��������
    //public Animator animator; //�ִϸ��̼�
    private bool isGround = false; //��������
     
    [SerializeField] Transform pos; //�������� ��üũ �������ٰ���
    [SerializeField] float checkRadius; //�������� ��üũ �������ٰ���
    [SerializeField] LayerMask layerMask; //�������� ��üũ �������ٰ���
    private static player_Move instance;

    private void Awake()
    {
        if (instance == null) //Awake�� palyer ��ȯ �ı�����
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
        //animator.SetBool("Move", false); //���ϸ��̼�
    }

    // Update is called once per frame
    void Update()
    {

        float direction = Input.GetAxis("Horizontal"); //������ �̵� �� �ִϸ��̼� ����

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

        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, layerMask); //����
        //Debug.Log("isGround: " + isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rd.AddForce(Vector3.up * jumpforce);
            //Debug.Log("����");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // ����Ʈ ������ ������ �������߿��� ���� �ӵ�����
        {
            speed = 10;
            //Debug.Log("�޸�����");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // ����
        {
            speed = 5;
            //Debug.Log("�ȴ���");
        }
    }
}
