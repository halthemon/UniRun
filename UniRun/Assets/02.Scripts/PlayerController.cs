using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망 시 재생할 오디오클립
    public float jumpForce = 700f; // 점프력
    private int jumpCount = 0; // 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았나 안닿았나
    private bool isDead = false; // 죽었나 안죽었나

    private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

    private void Start() // 초기 설정
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update() // 실시간 갱신 설정
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
    private void Die()// 죽으면
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 장애물과의 충돌
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥과의 감지 (닿음)
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥과의 감지2 (안닿음)
    }
}