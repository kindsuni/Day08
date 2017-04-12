using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youwon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;

    public static GM instance = null;

    private GameObject clonePaddle; //패들의 클론.
    //싱글턴.
    private void Awake() //게임 내에서 유일하게 존재해야 하는 경우사용(게임매니저, 로직 등등)
    {
        if (instance == null)//없으면 새로 만듬.
        {
            instance = this;
        }
        else if (instance != this) //이미 이전에 만들어져있으니 자기자신을 지우고 이전것을 사용.
        {
            Destroy(gameObject);
        }
        Setup(); //초기화 메서드.
    }
    public void Setup()
    { //패들을 생성      생성       오브젝트,  바인딩된오브젝트 위치,  회전각도만큼(indentity는 회전값없다).
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity); //블록 생성.
    }
    public void DestroyBrick()
    {
        bricks--;

    }
}