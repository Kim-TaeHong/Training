using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프를 구현.
        if (Input.GetButtonDown("Jump") && this.rigid.velocity.y == 0)
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        //좌우로 이동을 구현.
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 좌우로 이동 시 이미지 반전을 구현.
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }

    void FixedUpdate()
    {
        //캐릭터의 속도를 조절함.
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }


    //객체가 Circle에 닿으면 ClearScene를 호출함.

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.name == "Circle")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
