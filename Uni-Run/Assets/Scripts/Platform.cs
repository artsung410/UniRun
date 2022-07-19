using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour 
{
    private int _obstacleCount;
    private GameObject[] _obstacles; // 장애물 오브젝트들
    private bool _isStepped = false; // 플레이어 캐릭터가 밟았었는가


    public int randMax = 0;
    public int randMin = 4;
    int randNum = 0;

    private void Awake()
    {
        _obstacleCount = transform.childCount;
        _obstacles = new GameObject[_obstacleCount];
        for (int i = 0; i < _obstacleCount; ++i)
        {
            _obstacles[i] = transform.GetChild(i).gameObject;
        }

        randNum = Random.RandomRange(randMax, randMin);
    }
    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable() 
    {
        _isStepped = false;

        // 장애물을 활성화 비화성화 해야함, 확률은 본인 하고싶은대로
        // Ex, 25%확률로 활성화 된다.

        for (int i = 0; i < _obstacleCount; ++i)
        {
            if (i == randNum)
            {
                _obstacles[i].SetActive(true);
            }
            else
            {
                _obstacles[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        randNum = Random.RandomRange(randMax, randMin);
    }


    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_isStepped == false)
            {
                _isStepped = true;
                GameManager.Instance.AddScore();
            }

        }
    }
}