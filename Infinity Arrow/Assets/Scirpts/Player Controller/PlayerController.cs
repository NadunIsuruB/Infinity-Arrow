using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Retry;

    public Text DebugingText;

    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 direction;


    private void Start()
    {
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // void FixedUpdate()
    // {
    //     
    //     //.Translate(Vector3.up * Time.deltaTime * 5f);
    // }

    private void Update()
    {
#if UNITY_EDITOR
        List<Touch> touches = InputHelper.GetTouches();

        transform.Translate(Vector2.up * Time.deltaTime * 8f);
        if (touches.Count > 0)
        {
            //Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touches[0].position);
            touchPos.z = 0f;
            direction = (touchPos - transform.position);

            rb.velocity = new Vector2(direction.x * Time.deltaTime * 500f, 0f);

            if (touches[0].phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }

            DebugingText.text = "UNITY_EDITOR";
            // //transform.position = new Vector3(touchPos.x, transform.position.y, transform.position.z);
        }

#else
        transform.Translate(Vector2.up * Time.deltaTime * 8f);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            direction = (touchPos - transform.position);

            rb.velocity = new Vector2(direction.x * Time.deltaTime * 200f, 0f);

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
            DebugingText.text = "MOBILE_PHONE";
            // //transform.position = new Vector3(touchPos.x, transform.position.y, transform.position.z);
        }
#endif
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            Instantiate(PlatformManager.instance.Platforms[Random.Range(0, PlatformManager.instance.Platforms.Count)], new Vector2(0, transform.position.y + 40f), Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT Enemy");
            Retry.SetActive(true);
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if (collision.gameObject.CompareTag("Marks"))
        {
            Debug.Log("HIT Mark");
            ScoreManager.instance.Score += Random.Range(3, 6);
            Destroy(collision.gameObject);
        }
    }
}
