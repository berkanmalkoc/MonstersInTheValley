using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanavarCan : MonoBehaviour
{
    float totalhealth = 100;
    float currenthealth;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = totalhealth;
        healthBar.fillAmount = currenthealth / totalhealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "balta")
        {
            currenthealth -= 5;
            healthBar.fillAmount = currenthealth / totalhealth;
        }
    }

    public void CanAzaltma(int azalmamiktari)
    {
        currenthealth -= azalmamiktari;
        healthBar.fillAmount = currenthealth / totalhealth;
    }
}
