using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookPlayer : MonoBehaviour
{
    public Transform Player;
    public Transform head;
    public int height,x,y,z;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        head.LookAt(Player.position+ new Vector3(0, 13, 0));
        head.transform.Rotate(new Vector3(180, 0, 0));
    }
    public void destroyself()
    {
        this.gameObject.SetActive(false);
    }
}
