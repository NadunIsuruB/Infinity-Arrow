using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            Instantiate(PlatformManager.instanse.Platforms[Random.Range(0, 2)],new Vector2(0, transform.position.y + 20f), Quaternion.identity);
        }
    }
}
