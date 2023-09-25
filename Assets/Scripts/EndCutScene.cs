using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    public GameObject Player;
    public GameObject CutSceneObject;
    public GameObject TimeLineObject;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(true);
        CutSceneObject.SetActive(false);
        TimeLineObject.SetActive(false);
    }

   
}
