using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 destination;
    private bool isShooting =true;

    [SerializeField]
    private float fireRate = 0.4f;
    [SerializeField]
    private GameObject bulletPrefrab;
    [SerializeField]
    private Transform bulletSpawnPoint;

    public  AudioSource aus;
    public AudioClip shootingSound;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
      if(Input.GetMouseButton(0))
      {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.Lerp
        (transform.position ,new Vector3(destination.x,destination.y,transform.position.z),0.1f);
      }
      if(isShooting){
          StartCoroutine(Shoot());
      }
    }

    IEnumerator Shoot()
    {
      // khoi tao1 vien dan o vi tri cua bullerprefrab, goc mac dinh theo goc cua bullerprefrab
      Instantiate(bulletPrefrab,bulletSpawnPoint.position, Quaternion.identity);
      // phat am thanh
      if(aus && shootingSound)
      {
         aus.PlayOneShot(shootingSound);
      }
      isShooting = false;
      yield return new WaitForSeconds(fireRate);
        isShooting = true;

    }

}
