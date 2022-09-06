using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{
    #region Kol Silahlar
    [SerializeField] GameObject kolBalta;
    [SerializeField] GameObject kolMp5;
    #endregion

    [SerializeField] GameObject pressF;

    bool baltaal�nabilir = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (baltaal�nabilir)
            {
                BaltaActive();
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag== "baltaal")
        {
            pressF.SetActive(true);
            baltaal�nabilir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "baltaal")
        {
            pressF.SetActive(false);
            baltaal�nabilir = false;
        }
    }

    void BaltaActive()
    {
        kolBalta.SetActive(true);
        kolMp5.SetActive(false);
    }

    void Mp5Active()
    {
        kolBalta.SetActive(false);
        kolMp5.SetActive(true);
    }

}
