using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
  [SerializeField]
  private float bulletSpeed;
  [SerializeField]
  private float bulletDamage;
  private Rigidbody2D myBody;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("Block"))
      {
      Debug.Log("OnTriggerEnter2D with Block");
      collision.SendMessageUpwards("OnDameged", bulletDamage);
    }
    if(!collision.CompareTag("Bullet"))
    {
      Destroy(gameObject);
    }
  }

}
