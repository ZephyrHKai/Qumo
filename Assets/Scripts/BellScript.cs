using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip StartClip;
    public AudioClip LoopClip;

    public GameObject Die;
    private float game_time;

    private float interval_time = 60;
    void Start()
    {
        
        game_time = Die.transform.GetComponent<Failscene>().GameTime;
        Debug.Log(game_time);
        //StartCoroutine(TwoSoundsPerMin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RingBellOnce()
    {
        this.GetComponent<AudioSource>().clip = StartClip;
        this.GetComponent<AudioSource>().Play(0);
    }

    // void ()
    // {
    //     RingBellOnce();
    //     yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
    //     audio.clip = engineLoopClip;
    //     audio.Play();
    // }



    IEnumerator RingBellTwice()
    {
        this.GetComponent<AudioSource>().loop = true;
        RingBellOnce();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
        RingBellOnce();
        this.GetComponent<AudioSource>().loop = false;
    }

    IEnumerator RingBellThreeTimes()
    {
        this.GetComponent<AudioSource>().loop = true;
        RingBellOnce();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length * 2+ 0.1f);
        this.GetComponent<AudioSource>().loop = false;
    }


    IEnumerator RingBellFourTimes()
    {
        this.GetComponent<AudioSource>().loop = true;
        RingBellOnce();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length * 3 + 0.1f);
        this.GetComponent<AudioSource>().loop = false;
    }


    public IEnumerator OneSoundPerMin()
    {
        Debug.Log("Playing OneSoundsPerMin");
        float i = game_time;
        
        while ( i > interval_time )
        {
            yield return new WaitForSeconds(interval_time);
            RingBellOnce();
            i = i - interval_time;
        }
    }

    public IEnumerator TwoSoundsPerMin()
    {
        Debug.Log("Playing TwoSoundsPerMin");
        float i = game_time;

        while (i > interval_time)
        {
            yield return new WaitForSeconds(interval_time);
            StartCoroutine(RingBellTwice());
            i = i - interval_time;
        }
    }

    public IEnumerator ThreeSoundsPerMin()
    {
        Debug.Log("Playing ThreeSoundsPerMin");
        float i = game_time;

        while (i > interval_time)
        {
            yield return new WaitForSeconds(interval_time);
            StartCoroutine(RingBellThreeTimes());
            i = i - interval_time;
        }
    }

    public IEnumerator FourSoundsPerMin()
    {
        
        float i = game_time;

        while (i > interval_time)
        {
            yield return new WaitForSeconds(interval_time);
            StartCoroutine(RingBellFourTimes());
            i = i - interval_time;
        }
    }






    
}
