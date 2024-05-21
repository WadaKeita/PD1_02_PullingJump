using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    private float jumpPower = 6;

    private bool isCanJump;
    private bool isJump;

    //private bool isCollisionExit;

    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
        Debug.Log("�Փ˂���");
    }

    private void OnCollisionStay(Collision collision)
    {
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̕������擾�B
        Vector3 otherNormal = contacts[0].normal;
        // ������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);
        // ������Ɩ@���̓��ρB��̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁAcos�Ƃ̌��ʂ�dotUN�ϐ��ɓ���B
        float dotUN = Vector3.Dot(upVector, otherNormal);
        // ���ϒl�ɋt�O�p�֐�arccos���|���Ċp�x���Z�o�B�����x���@�֕ϊ�����B����Ŋp�x���Z�o�ł����B
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        // ��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�Ƃ���B
        if (dotDeg <= 45)
        {
            isCanJump = true;
            Debug.Log("�n�ʂƏՓ˂���");
        }

        Debug.Log("�ڑ���");
        //isCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {

        if (isJump == true)
        {
            isCanJump = false;
        }
        Debug.Log("���E����");
        //isCanJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();  // gameObject�͏ȗ��\�I

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if (dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���B
            rb.velocity = dist.normalized * jumpPower;
            
            isCanJump = false;
            isJump = true;
        }
        //if(rb.velocity == Vector3.zero)
        //{
        //    isCanJump = true;
        //}
    }
}
