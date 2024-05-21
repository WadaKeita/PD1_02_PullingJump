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
        Debug.Log("衝突した");
        isCanJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("接続中");
        //isCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱した");
        //isCanJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();  // gameObjectは省略可能！

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
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;
            // クリックとリリースが同じ座標ならば無視
            if (dist.sqrMagnitude == 0) { return; }
            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする。
            rb.velocity = dist.normalized * jumpPower;

            isCanJump= false;
        }
    }
}
