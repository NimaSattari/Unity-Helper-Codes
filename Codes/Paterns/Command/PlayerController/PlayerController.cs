using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    float speed = 2.0f;
    float rotationSpeed = 100.0f;

    void Start()
    {
        anim = this.GetComponent<Animatior>();
    }

    void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeUp(KeyCode.DownArrow) || Input.GetKeUp(KeyCode.LeftArrow) || Input.GetKeUp(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKe(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(0, 0, translation);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKe(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(0, translation, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("isPunching");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("isKicking");
        }
    }
}