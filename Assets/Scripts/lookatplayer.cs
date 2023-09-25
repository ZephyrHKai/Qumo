using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatplayer : MonoBehaviour
{
    public Transform Player;
    public Transform head;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        head.LookAt(Player);
        head.transform.Rotate(new Vector3(0, -90, -90));
    }
    public void destroyself() {
        this.gameObject.SetActive(false);
    }
}
