using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour {

    public Transform start;
    public Transform really;
    public int score = 0;
    public GameObject pinPerfab;
    public pin nowpin;
    public bool isGameOver = false;
    public Text scoretext;
    public Camera mainCamera;
    public float speed = 3;
	// Use this for initialization
	void Start () {
        start = GameObject.Find("start").transform;
        really = GameObject.Find("really").transform;
        mainCamera = Camera.main;
        setpin();
	}

    private void Update()
    {
        if (isGameOver)
            return;
        if(Input.GetMouseButtonDown(0))
        {
            score++;
            scoretext.text = score.ToString();
            nowpin.StartFly();
            setpin();
        }
    }

    // Update is called once per frame
    void setpin () {
        nowpin = GameObject.Instantiate(pinPerfab, really.position, pinPerfab.transform.rotation).GetComponent<pin>();
		
	}
    public void GameOver()
    {
        if (isGameOver)
            return;
        GameObject.Find("Circle").GetComponent<xuanzhuan>().enabled = false;
        StartCoroutine(GameOverAnimaation());
        isGameOver = true;
    }
     IEnumerator GameOverAnimaation()
    {
        while(true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, speed * Time.deltaTime);
            if(Mathf.Abs(mainCamera.orthographicSize-4)<=0.01f)
            {
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
