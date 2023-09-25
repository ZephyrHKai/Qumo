using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Failscene : MonoBehaviour
{
    public Camera mc;
    public int Timee = 30;
    public GameObject xiaren;
    public GameObject resultManager;
    public bool isdead;
    public float timeSpeed = 1;//Start is called before the first frame update

    public Text countDownDisplay;
    public float GameTime;
    public float fullGameTime;
    void Start()
    {
        this.gameObject.transform.position = mc.transform.position + mc.transform.forward.normalized *50;
        resultManager = GameObject.Find("ResultManager");
        GameTime = fullGameTime;
        //speed = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        countDownDisplay.text = ((int)GameTime).ToString();
        if (isdead)
        {
            this.gameObject.transform.position = mc.transform.position + mc.transform.forward.normalized * Timee;
            // this.gameObject.transform.position= Vector3.MoveTowards(this.gameObject.transform.position, mc.transform.position, 50*Time.deltaTime);
            this.transform.forward = new Vector3(-mc.transform.forward.x, -mc.transform.forward.y, -mc.transform.forward.z);
        }
        if (GameTime <= 0) {
            isdead = true;
            xiaren.SetActive(true);
        }
        if (resultManager.GetComponent<ResultManager>().fail) {
            isdead = true;
            xiaren.SetActive(true);
            StartCoroutine(returnToMainScene());
        }

    }
    private void FixedUpdate()
    {
        if (GameTime > 0) {
            GameTime -= Time.deltaTime*timeSpeed;
        }
       
        
        if (isdead&& Timee >= 5)
        {
            Timee--;
        }
    }
    IEnumerator returnToMainScene()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }

}
