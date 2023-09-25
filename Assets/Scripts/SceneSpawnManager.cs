using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;



public class SceneSpawnManager : MonoBehaviour
{
    // Chairs 
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

    //  clock time 
    [SerializeField] GameObject clock; 
    [SerializeField] GameObject Bell;
    [SerializeField] GameObject mask;

    public List<Material> mask_material_list = new List<Material>();
    public List<Material> skybox_list = new List<Material>();
    private List<int> skybox_list_index = new List<int>(){0, 1 , 2, 3};
    private int skybox_index ;
    private List<int> random_hour = new List<int>(){ 11, 11, 12, 12 };
    private List<int> random_minutes = new List<int>() { 10, 20, 10, 20 }; 

    // seal list 
    public List<GameObject> seal_position_list = new List<GameObject>();
    public List<Sprite> seal_sprite_list_A = new List<Sprite>();
    public List<Sprite> seal_sprite_list_B = new List<Sprite>();
    public List<Sprite> seal_sprite_list_C = new List<Sprite>();


    private List<int> temperature_list = new List<int>(){11, 18, 30};

    private List<string>  ghost_list = new List<string>() {"A", "B", "C", "D", "E", "F"};

    private string current_ghost;

    // Questions 
    public GameObject yes_green;
    public GameObject no_green;
    public GameObject yes_red;
    public GameObject no_red;


    // randomize temperature
    public int temperature;
    [SerializeField] GameObject thermometer;
    void Start()
    {   
        // random ghost type
        ghost_list.Shuffle();
        current_ghost = ghost_list[0];
        // current_ghost = "A";
        Debug.Log("The Ghost is" + current_ghost);


        // skybox
        skybox_list_index.Shuffle();
        skybox_index = skybox_list_index[0];
        Debug.Log("the skybox is " + skybox_index);
        RenderSettings.skybox = skybox_list[skybox_index];


        //  Seal
        seal_sprite_list_A.Shuffle();
        seal_sprite_list_B.Shuffle();
        seal_sprite_list_C.Shuffle();

        seal_position_list[0].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[0];
        for (int i = 0; i < 2; i++)
        {
            seal_position_list[i].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[i];
        }
        for (int i = 2; i < 4; i++)
        {
            seal_position_list[i].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[i - 2];
        }
        for (int i = 4; i < 6; i++)
        {
            seal_position_list[i].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[i - 4];
        }

        spawnGhost();
        spawnCorrectCandlePosition(current_ghost);
        

        // A 
        if (current_ghost == "A")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 4);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];

            // temperature

            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {
                // 10 - 30 
                display_temperature(10,30); 
            }
            if (skybox_index == 1)
            {
                display_temperature(5, 25);
            }
            if (skybox_index == 2)
            {
                display_temperature(0, 20);
            }
            if (skybox_index == 3)
            {
                display_temperature(-5, 15);
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if ( isEven(ran)) 
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().OneSoundPerMin());
            } else 
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().ThreeSoundsPerMin());
            }

            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[0];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[3];
            }


            //Seal 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
            }
            else
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
            }



            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                yes_red.SetActive(true);
            }
            else
            {
                no_green.SetActive(true);
            }

            // chair 
            if (chair9.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair9.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair14.transform.GetComponent<ChairManager>().isRealGhost = true;
            }


        }


        // B 
        if (current_ghost == "B")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 4);
            // Debug.Log("ran is " + ran);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];


            //Seal 
            if (ran == 0 || ran == 1)
            {
                if (isEven(ran))
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[3];
                }
                else
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
                }
            }
            else
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
            }



            // temperature 
            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {   
                if (isEven(ran)) {display_temperature(15, 25); }
                else {display_temperature(5, 10); }  
            }
            if (skybox_index == 1)
            {
                if (isEven(ran)) { display_temperature(10, 20); }
                else { display_temperature(25, 30); }
            }
            if (skybox_index == 2)
            {
                if (isEven(ran)) { display_temperature(5, 15); }
                else { display_temperature(-5, 0); }
            }
            if (skybox_index == 3)
            {
                if (isEven(ran)) { display_temperature(0, 10); }
                else { display_temperature(15, 20); }
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if ( isEven(ran))
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().TwoSoundsPerMin());
            }
            else
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().FourSoundsPerMin());
            }

            

            





            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[1];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[2];
            }


            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                no_red.SetActive(true);
            }
            else
            {
                yes_green.SetActive(true);
            }

            // chair 
            if (chair10.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair10.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair7.transform.GetComponent<ChairManager>().isRealGhost = true;
            }

        }


        // C  
        if (current_ghost == "C")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 2);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];

            // temperature

            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {
                // 10 - 30 
                display_temperature(10, 15);
            }
            if (skybox_index == 1)
            {
                display_temperature(5, 10);
            }
            if (skybox_index == 2)
            {
                display_temperature(15, 20);
            }
            if (skybox_index == 3)
            {
                display_temperature(10, 15);
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().OneSoundPerMin());
            }
            else
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().ThreeSoundsPerMin());
            }

            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[1];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[2];
            }

            //  Seal 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[3];
            }
            else
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
            }


            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                yes_red.SetActive(true);
            }
            else
            {
                no_green.SetActive(true);
            }

            // chair 
            if (chair8.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair8.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair3.transform.GetComponent<ChairManager>().isRealGhost = true;
            }

        }

        // D  
        if (current_ghost == "D")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 4);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];

            // Seal 

            if (ran == 0 || ran == 1)
            {
                if (isEven(ran))
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[3];
                }
                else
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
                }
            }
            else
            {
                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
            }


            // temperature
            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {
                // 10 - 30 
                display_temperature(20, 25);
            }
            if (skybox_index == 1)
            {
                display_temperature(15, 20);
            }
            if (skybox_index == 2)
            {
                display_temperature(10, 15);
            }
            if (skybox_index == 3)
            {
                display_temperature(5, 10);
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().TwoSoundsPerMin());
            }
            else
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().FourSoundsPerMin());
            }

            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[0];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[3];
            }

            


            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                yes_red.SetActive(true);
            }
            else
            {
                no_green.SetActive(true);
            }

            // chair 
            if (chair6.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair6.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair11.transform.GetComponent<ChairManager>().isRealGhost = true;
            }

        }

        // E  
        if (current_ghost == "E")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 4);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];

            // Seal 

            if (ran == 0 || ran == 1)
            {
                if (isEven(ran))
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_A[3];
                }
                else
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
                }
            }
            else
            {
                if (isEven(ran))
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
                }
                else
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
                }
            }


            // temperature
            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {
                // 10 - 30 
                display_temperature(10, 30);
            }
            if (skybox_index == 1)
            {
                display_temperature(5, 25);
            }
            if (skybox_index == 2)
            {
                display_temperature(0, 20);
            }
            if (skybox_index == 3)
            {
                display_temperature(-5, 15);
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().OneSoundPerMin());
            }
            else
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().ThreeSoundsPerMin());
            }

            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[1];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[2];
            }

            


            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                no_red.SetActive(true);
            }
            else
            {
                yes_green.SetActive(true);
            }


            // chair 
            if (chair4.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair4.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair13.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
        }


        // F  
        if (current_ghost == "F")
        {
            // random clock time 
            int ran = UnityEngine.Random.Range(0, 4);
            clock.GetComponent<Clock>().hour = random_hour[ran];
            clock.GetComponent<Clock>().minutes = random_minutes[ran];

            // Seal 
            if (ran == 0 || ran == 1)
            {

                seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];

            }
            else
            {
                if (isEven(ran))
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_B[3];
                }
                else
                {
                    seal_position_list[6].transform.GetComponent<SpriteRenderer>().sprite = seal_sprite_list_C[3];
                }
            }


            // temperature
            // skybox0 = 20
            //1 = 15
            // 2 = 10
            // 3 = 5
            if (skybox_index == 0)
            {
                // 10 - 30 
                display_temperature(30, 35);
            }
            if (skybox_index == 1)
            {
                display_temperature(25, 30);
            }
            if (skybox_index == 2)
            {
                display_temperature(20, 25);
            }
            if (skybox_index == 3)
            {
                display_temperature(15, 20);
            }


            // bell 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().TwoSoundsPerMin());
            }
            else
            {
                StartCoroutine(Bell.transform.GetComponent<BellScript>().ThreeSoundsPerMin());
            }

            // mask 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[0];
            }
            else
            {
                mask.transform.GetComponent<MeshRenderer>().material = mask_material_list[3];
            }

            

            // Question 
            ran = UnityEngine.Random.Range(0, 4);
            if (isEven(ran))
            {
                yes_red.SetActive(true);
            }
            else
            {
                no_green.SetActive(true);
            }


            // chair 
            if (chair5.transform.GetComponent<ChairManager>().isGhost == true)
            {
                chair5.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
            else
            {
                chair12.transform.GetComponent<ChairManager>().isRealGhost = true;
            }
        }




        // // random seal list 
        // seal_list.Shuffle();
        // for (int i = 0; i < 4; i++)
        // {
        //     seal_list[i].SetActive(true);
        // }


        // // foreach (var seal in seal_list)
        // // {
        // //     Debug.Log(seal);
        // // }

        // // random temperature 

        // temperature_list.Shuffle();
        // thermometer.transform.GetComponent<TextMesh>().text = temperature_list[0].ToString() + "°C";

        // random skyball 


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  display_temperature(int down, int up)
    {
        thermometer.transform.GetComponent<TextMesh>().text = UnityEngine.Random.Range(down, up).ToString() + "°C";
    }


    private bool isEven (int i)
    {
        return i % 2 == 0;
    }

    private void spawnGhost()
    {   
        // A
        int ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair9.transform.GetComponent<ChairManager>().isGhost = true;
             //Debug.Log("ghost A spawn at 9");
        }
        else
        {
            chair14.transform.GetComponent<ChairManager>().isGhost = true;
            // Debug.Log("ghost A spawn at 14");
        }

        //c
        ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair3.transform.GetComponent<ChairManager>().isGhost = true;
        }
        else
        {
            chair8.transform.GetComponent<ChairManager>().isGhost = true;
        }

        // D
        ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair6.transform.GetComponent<ChairManager>().isGhost = true;
        }
        else
        {
            chair11.transform.GetComponent<ChairManager>().isGhost = true;
        }

        // B
        ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair10.transform.GetComponent<ChairManager>().isGhost = true;
        }
        else
        {
            chair7.transform.GetComponent<ChairManager>().isGhost = true;
        }

        // E
        ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair13.transform.GetComponent<ChairManager>().isGhost = true;
        }
        else
        {
            chair4.transform.GetComponent<ChairManager>().isGhost = true;
        }

        // F
        ran = UnityEngine.Random.Range(0, 4);
        if (isEven(ran))
        {
            chair5.transform.GetComponent<ChairManager>().isGhost = true;
        }
        else
        {
            chair12.transform.GetComponent<ChairManager>().isGhost = true;
        }

    }


    private void spawnCorrectCandlePosition(String ghost)
    {
        if (ghost == "A" || ghost == "C" )
        {
            chair1.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair4.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair6.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair7.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair10.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair11.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair13.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair16.transform.GetComponent<ChairManager>().correct_candle_position = true;
        }

        if (ghost == "B" || ghost == "D")
        {
            chair2.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair3.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair5.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair8.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair9.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair12.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair14.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair15.transform.GetComponent<ChairManager>().correct_candle_position = true;
        }

        if (ghost == "E" || ghost == "F")
        {
            chair2.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair6.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair7.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair8.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair9.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair10.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair11.transform.GetComponent<ChairManager>().correct_candle_position = true;
            chair15.transform.GetComponent<ChairManager>().correct_candle_position = true;
        }


    }



}

// shuffle a list 
public static class Extensions
{
    private static System.Random rand = new System.Random();
    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}