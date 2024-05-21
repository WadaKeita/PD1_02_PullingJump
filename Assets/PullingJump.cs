using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    private float jumpPower = 6;

    private bool isCanJump;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
        isCanJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("�ڑ���");
        //isCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
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

            isCanJump= false;
        }
    }
}
