using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooter : MonoBehaviour
{
    public bool shooterBool = true; //ateþ edebilir mi
    float shooterFrequency;  // ATEÞ SIKLIÐI
    public float shooterFrequencyOut; //Dýþardan deðer gir.Ateþ sýklýðý
    public float Range;  //Silah menzili
    public Camera myCam;
    public AudioSource[] gunSound;
    public ParticleSystem[] gunEffect;
    public Image Scope;
    public Sprite on;
    public Sprite off;
    public Animator Gun;
    [SerializeField] int capacity;             //toplam kapasite 120
    [SerializeField] int remainingBullet = 30;   //kalan mermi
    [SerializeField] int magazineCapasity = 30;  //þarjörün kapasitesi

    public Text capacityText;
    public Text remainingBulletText;


    void Start()
    {
        remainingBullet = magazineCapasity;
        remainingBulletText.text = remainingBullet.ToString();
        capacityText.text = capacity.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && (remainingBullet <= 0))
        {
            Gun.SetBool("isAmmoOut", false);
            //shooterBool = false;
            Gun.SetBool("isFire", false);
            //StartCoroutine(ReloadGun());
        }
        if (Input.GetKey(KeyCode.Mouse0) && shooterBool && Time.time > shooterFrequency && remainingBullet != 0) //ateþ
        {
            Scope.GetComponent<Image>().sprite = on;
            Fire();
            shooterFrequency = Time.time + shooterFrequencyOut;
            Gun.SetBool("isFire", true);


        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) //Scope
        {
            Scope.GetComponent<Image>().sprite = off;
            Gun.SetBool("isFire", false);
        }


        if (Input.GetKeyDown(KeyCode.R) && remainingBullet < magazineCapasity)
        {
            if (remainingBullet != magazineCapasity)
            {
                StartCoroutine(ReloadGun());
            }
            if (remainingBullet < magazineCapasity && capacity != 0)
            {
                if (remainingBullet != 0)
                {
                    int sumValue = remainingBullet + capacity;
                    if (capacity <= magazineCapasity)
                    {
                        remainingBullet = magazineCapasity;
                        capacity = sumValue - magazineCapasity;
                    }
                    else
                    {
                        remainingBullet += capacity;
                        capacity = 0;
                    }
                }
                else
                {
                    if (capacity <= magazineCapasity)
                    {
                        remainingBullet = capacity;
                        capacity = 0;
                    }
                    else
                    {
                        capacity -= magazineCapasity;
                        remainingBullet = magazineCapasity;
                    }

                    capacityText.text = capacity.ToString();
                    remainingBulletText.text = remainingBullet.ToString();

                }
            }


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bulletGet();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bulletSave(other.transform.gameObject.GetComponent<BulletBox>().producedGun, other.transform.gameObject.GetComponent<BulletBox>().producedBullet);
        Destroy(other.transform.gameObject);
    }
    IEnumerator ReloadGun()
    {
        gunSound[1].Play();
        Gun.SetBool("isAmmoOut", true);
        yield return new WaitForSeconds(.5f);
        Gun.SetBool("isAmmoOut", false);
    }
    void Fire()
    {
        remainingBullet--;
        remainingBulletText.text = remainingBullet.ToString();
        RaycastHit hit;
        gunSound[0].Play();//Silah atýþ sesi
        gunEffect[0].Play(); //Silah patlama 



        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Range))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Instantiate(gunEffect[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if (hit.transform.gameObject.CompareTag("Object"))
            {
                Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
                rg.AddForce(-hit.normal * 50f); //Obejeyi mermi ile düþürme
                Instantiate(gunEffect[1], hit.point, Quaternion.LookRotation(hit.normal));

            }
            else
            {
                Instantiate(gunEffect[1], hit.point, Quaternion.LookRotation(hit.normal));
            }

        }

    }
    void bulletGet()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, 3))
        {
            if (hit.transform.gameObject.CompareTag("bullet"))
            {
                bulletSave(hit.transform.gameObject.GetComponent<BulletBox>().producedGun, hit.transform.gameObject.GetComponent<BulletBox>().producedBullet);
                Destroy(hit.transform.gameObject);        
            }
        }

    }

    void bulletSave(string Gun, int bulletCount)
    {
        switch (Gun)
        {
            case "Gun1":
                capacity += bulletCount;
                remainingBulletText.text = remainingBullet.ToString();
                capacityText.text = capacity.ToString();
                break;
            case "Gun2":
                capacity += bulletCount;
                break;


            case "Gun3":
                capacity += bulletCount;
                break;
            case "Gun4":
                capacity += bulletCount;
                break;
        }

    }
}
