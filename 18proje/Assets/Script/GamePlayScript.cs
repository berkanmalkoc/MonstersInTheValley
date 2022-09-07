using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{
    #region Kol ve Silahlar
    [SerializeField] GameObject kolBalta;
    [SerializeField] GameObject kolMp5;
    #endregion

    [SerializeField] GameObject pressF;

    bool mp5envanterde=false;
    bool baltaenvanterde = false;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (baltaenvanterde)
            {
                BaltaActive();
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (mp5envanterde)
            {
                Mp5Active();
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag== "baltaal")
        {
            pressF.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
              
                Destroy(other.gameObject);
                BaltaActive();
                pressF.SetActive(false);
                baltaenvanterde = true;

                
            }
        }

        if (other.gameObject.tag == "mp5al")
        {
            pressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                mp5envanterde = true;
                Destroy(other.gameObject);
                Mp5Active();
                pressF.SetActive(false);



            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "baltaal")
        {
            pressF.SetActive(false);
        }

        if (other.gameObject.tag == "mp5al")
        {
            pressF.SetActive(false);
        }
    }



    void BaltaActive()
    {
        kolMp5.SetActive(false);
        kolBalta.SetActive(true);
        
    }

    void Mp5Active()
    {
        kolBalta.SetActive(false);
        kolMp5.SetActive(true);
    }

}
