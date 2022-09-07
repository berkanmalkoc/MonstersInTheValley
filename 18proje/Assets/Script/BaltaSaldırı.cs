using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaltaSaldırı : MonoBehaviour
{
    [SerializeField] GameObject baltaCollider;
    public Animator baltaAnim;
    [SerializeField] float colliderkapamasüresi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            baltaAnim.SetBool("baltaSaldir", true);
            baltaCollider.SetActive(true);
            StartCoroutine(BaltaColliderKapa());
        }
        else
        {
            baltaAnim.SetBool("baltaSaldir", false);
            
        }

    }

    IEnumerator BaltaColliderKapa()
    {
        yield return new WaitForSecondsRealtime(colliderkapamasüresi);
        baltaCollider.SetActive(false);

    }
}
