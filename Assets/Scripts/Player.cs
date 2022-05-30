using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Sprite 관련 변수 생성
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    // 방향, 중력, 힘 변수 생성
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // AnimateSprite 메서드를 계속 반복함.
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 posreset = transform.position;
        posreset.y = 0f;
        transform.position = posreset;

        // new Vector3(0, 0, 0) 의 짧은 버전
        direction = Vector3.zero;
    }
    private void Update()
    {
        // 스페이스바 or 왼쪽 마우스 버튼이 눌렸는지 확인함.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // 몇개의 손가락으로 화면을 터치하고 있는지 확인함.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * strength;
            }
        }

        // y축으로 gravity * Time.deltaTime 만큼 값을 더해줌.
        direction.y += gravity * Time.deltaTime;
        
        // direction 값 * Time.deltaTime 만큼 transform.position 값을 더해줌.
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // 스프라이트를 sprites[spriteIndex] 로 바꿈.
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 장애물 인식
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        // 점수 획득
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
