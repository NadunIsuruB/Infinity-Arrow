using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   // void FixedUpdate()
   // {
   //     
   //     //.Translate(Vector3.up * Time.deltaTime * 5f);
   // }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            direction = (touchPos - transform.position);

            //rb.velocity = new Vector2(direction.x * Time.deltaTime * 200f, rb.velocity.y);

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector2(0, 1f * Time.deltaTime * 200f);
            }
            else
            {
                rb.velocity = new Vector2(direction.x * Time.deltaTime * 200f, 1f * Time.deltaTime * 200f);
            }
            // //transform.position = new Vector3(touchPos.x, transform.position.y, transform.position.z);
        }
        else
        {
            rb.velocity = new Vector2(0f, 1f * Time.deltaTime * 200f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            Instantiate(PlatformManager.instanse.Platforms[Random.Range(0, 2)],new Vector2(0, transform.position.y + 40f), Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
        }
    }
}
