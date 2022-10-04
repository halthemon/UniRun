using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ��� �� ����� �����Ŭ��
    public float jumpForce = 700f; // ������
    private int jumpCount = 0; // ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��ҳ� �ȴ�ҳ�
    private bool isDead = false; // �׾��� ���׾���

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ

    private void Start() // �ʱ� ����
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update() // �ǽð� ���� ����
    {
        if(isDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        { 
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }
    private void Die()// ������
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��ֹ����� �浹
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڰ��� ���� (����)
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڰ��� ����2 (�ȴ���)
    }
}