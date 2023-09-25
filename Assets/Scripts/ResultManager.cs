using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject chair1;
    [SerializeField] GameObject chair2;
    [SerializeField] GameObject chair3;
    [SerializeField] GameObject chair4;
    [SerializeField] GameObject chair5;
    [SerializeField] GameObject chair6;
    [SerializeField] GameObject chair7;
    [SerializeField] GameObject chair8;
    [SerializeField] GameObject chair9;
    [SerializeField] GameObject chair10;
    [SerializeField] GameObject chair11;
    [SerializeField] GameObject chair12;
    [SerializeField] GameObject chair13;
    [SerializeField] GameObject chair14;
    [SerializeField] GameObject chair15;
    [SerializeField] GameObject chair16;
    public AudioSource JPS;
    private bool c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16;
    private bool s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16;
    private bool p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16;
    private bool g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16;
    public bool candlewin = false;
    public bool correctseal = false;
    public bool win;
    public bool fail;
    public GameObject winpanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c1 = chair1.GetComponent<ChairManager>().isOn;
        c2 = chair2.GetComponent<ChairManager>().isOn;
        c3 = chair3.GetComponent<ChairManager>().isOn;
        c4 = chair4.GetComponent<ChairManager>().isOn;
        c5 = chair5.GetComponent<ChairManager>().isOn;
        c6 = chair6.GetComponent<ChairManager>().isOn;
        c7 = chair7.GetComponent<ChairManager>().isOn;
        c8 = chair8.GetComponent<ChairManager>().isOn;
        c9 = chair9.GetComponent<ChairManager>().isOn;
        c10 = chair10.GetComponent<ChairManager>().isOn;
        c11 = chair11.GetComponent<ChairManager>().isOn;
        c12 = chair12.GetComponent<ChairManager>().isOn;
        c13 = chair13.GetComponent<ChairManager>().isOn;
        c14 = chair14.GetComponent<ChairManager>().isOn;
        c15 = chair15.GetComponent<ChairManager>().isOn;
        c16 = chair16.GetComponent<ChairManager>().isOn;


        p1 = chair1.GetComponent<ChairManager>().correct_candle_position;
        p2 = chair2.GetComponent<ChairManager>().correct_candle_position;
        p3 = chair3.GetComponent<ChairManager>().correct_candle_position;
        p4 = chair4.GetComponent<ChairManager>().correct_candle_position;
        p5 = chair5.GetComponent<ChairManager>().correct_candle_position;
        p6 = chair6.GetComponent<ChairManager>().correct_candle_position;
        p7 = chair7.GetComponent<ChairManager>().correct_candle_position;
        p8 = chair8.GetComponent<ChairManager>().correct_candle_position;
        p9 = chair9.GetComponent<ChairManager>().correct_candle_position;
        p10 = chair10.GetComponent<ChairManager>().correct_candle_position;
        p11 = chair11.GetComponent<ChairManager>().correct_candle_position;
        p12 = chair12.GetComponent<ChairManager>().correct_candle_position;
        p13 = chair13.GetComponent<ChairManager>().correct_candle_position;
        p14 = chair14.GetComponent<ChairManager>().correct_candle_position;
        p15 = chair15.GetComponent<ChairManager>().correct_candle_position;
        p16 = chair16.GetComponent<ChairManager>().correct_candle_position;

        g1 = chair1.GetComponent<ChairManager>().isRealGhost;
        g2 = chair2.GetComponent<ChairManager>().isRealGhost;
        g3 = chair3.GetComponent<ChairManager>().isRealGhost;
        g4 = chair4.GetComponent<ChairManager>().isRealGhost;
        g5 = chair5.GetComponent<ChairManager>().isRealGhost;
        g6 = chair6.GetComponent<ChairManager>().isRealGhost;
        g7 = chair7.GetComponent<ChairManager>().isRealGhost;
        g8 = chair8.GetComponent<ChairManager>().isRealGhost;
        g9 = chair9.GetComponent<ChairManager>().isRealGhost;
        g10 = chair10.GetComponent<ChairManager>().isRealGhost;
        g11 = chair11.GetComponent<ChairManager>().isRealGhost;
        g12 = chair12.GetComponent<ChairManager>().isRealGhost;
        g13 = chair13.GetComponent<ChairManager>().isRealGhost;
        g14 = chair14.GetComponent<ChairManager>().isRealGhost;
        g15 = chair15.GetComponent<ChairManager>().isRealGhost;
        g16 = chair16.GetComponent<ChairManager>().isRealGhost;


        s1 = chair1.GetComponent<ChairManager>().isSealed;
        s2 = chair2.GetComponent<ChairManager>().isSealed;
        s3 = chair3.GetComponent<ChairManager>().isSealed;
        s4 = chair4.GetComponent<ChairManager>().isSealed;
        s5 = chair5.GetComponent<ChairManager>().isSealed;
        s6 = chair6.GetComponent<ChairManager>().isSealed;
        s7 = chair7.GetComponent<ChairManager>().isSealed;
        s8 = chair8.GetComponent<ChairManager>().isSealed;
        s9 = chair9.GetComponent<ChairManager>().isSealed;
        s10 = chair10.GetComponent<ChairManager>().isSealed;
        s11 = chair11.GetComponent<ChairManager>().isSealed;
        s12 = chair12.GetComponent<ChairManager>().isSealed;
        s13 = chair13.GetComponent<ChairManager>().isSealed;
        s14 = chair14.GetComponent<ChairManager>().isSealed;
        s15 = chair15.GetComponent<ChairManager>().isSealed;
        s16 = chair16.GetComponent<ChairManager>().isSealed;

        // check right candle position 
        if ((c1 == p1) && (c2 == p2) && (c3 == p3) && (c4 == p4) && (c5 == p5) && (c6 == p6) && (c7 == p7) 
        && (c8 == p8) && (c9 == p9) && (c11 == p11) && (c12 == p12) && (c13 == p13) && (c14 == p14) && (c15 == p15) 
        && (c16 == p16) && (c10 == p10))
        {
            candlewin = true;
            Debug.Log("candlewin!!");
        }


        if ( s1 || s2 || s3|| s4|| s5|| s6|| s7|| s8|| s9|| s10|| s11|| s12|| s13|| s14|| s15|| s16) 
        {

            // check the right seal 
            if (!(right_seal(g1, s1) && right_seal(g2, s2) && right_seal(g3, s3) && right_seal(g4, s4) && right_seal(g5, s5)
            && right_seal(g6, s6) && right_seal(g7, s7) && right_seal(g8, s8) && right_seal(g9, s9) && right_seal(g10, s10)
            && right_seal(g11, s11) && right_seal(g12, s12) && right_seal(g13, s13) && right_seal(g14, s14) && right_seal(g15, s15)
            && right_seal(g16, s16)))
            {
                fail = true;
                if (!JPS.isPlaying)
                {
                    JPS.Play();
                }
                StartCoroutine(returnToMainScene());
                return;
            }
            
            if (candlewin)
            {
                win = true;
                winpanel.SetActive(true);
                winpanel.GetComponent<Animator>().Play("SuccessAnimation");
                StartCoroutine(returnToMainScene());

            }
            else {
                fail = true;
                if (!JPS.isPlaying)
                {
                    JPS.Play();
                }
                StartCoroutine(returnToMainScene());
            }
            
        }


    }


    private bool right_seal (bool true_ghost, bool is_seal)
    {
        if (is_seal)
        {
            if(!true_ghost){return false;}
        }
        return true;
    }




    IEnumerator returnToMainScene () 
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
}
