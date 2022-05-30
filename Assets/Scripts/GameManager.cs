using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // UI 요소 불러오기
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject backblack;

    // 점수 변수
    private int score;

    private void Start()
    {
        // 뒷 검은 배경 활성화
        backblack.SetActive(true);
    }

    private void Awake()
    {
        // 시작 시점에서 60 프레임 설정, 일시정지
        Application.targetFrameRate = 60;
        Pause();

        // UI 요소 비활성화
        gameOver.SetActive(false);
    }

    public void Play()
    {
        player.transform.position = new Vector3(0, 0, 0);

        score = 0;
        // scoreText.text 라는 상자 안에 score의 문자열 형태(score.ToString();) 를 넣음.
        scoreText.text = score.ToString();

        // UI 요소 비활성화
        playButton.SetActive(false);
        gameOver.SetActive(false);
        backblack.SetActive(false);

        // 플레이어 활성화
        player.enabled = true;


        // 시간 흐르기
        Time.timeScale = 1f;

        // 이해 안되는 부분!!
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }


    }

    public void Pause()
    {
        // 시간을 멈춘다.
        Time.timeScale = 0f;


        // 플레이어 비활성화
        player.enabled = false;
    }

    public void GameOver()
    {
        // UI 요소
        gameOver.SetActive(true);
        playButton.SetActive(true);


        // 게임 일시정지
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        // scoreText.text 라는 상자 안에 score의 문자열 형태(score.ToString();) 를 넣음.
        scoreText.text = score.ToString();
    }
}
