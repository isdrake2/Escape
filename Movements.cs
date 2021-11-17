using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    [SerializeField]
    float mouseSensitivity;

    [SerializeField]
    GameObject playerCamera;

    CharacterController cc;

    Vector3 moveVec;

    float downVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        moveVec = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            audio.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            audio.Stop();
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameLogic.activateTimer();
            moveVec.z = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameLogic.activateTimer();
            moveVec.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameLogic.activateTimer();
            moveVec.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameLogic.activateTimer();
            moveVec.x = 1;
        }
        if (Input.GetKey(KeyCode.Space) && cc.isGrounded)
        {
            gameLogic.activateTimer();
            downVelocity = -10;
        }
        if (Input.GetKey(KeyCode.Space) && cc.isGrounded)
        {
            gameLogic.activateTimer();
            ProjectileShoot(projectile);
        }

        cc.Move(transform.forward * moveVec.z * Time.deltaTime * speedMod);
        cc.Move(transform.right * moveVec.x * Time.deltaTime * speedMod);
        downVelocity += Time.deltaTime * 20f;

        if (cc.isGrounded && downVelocity > 0)
        {
            Debug.Log("Grounded");
            downVelocity = 0.1f;
        }
        else
        {
            Debug.Log("Not grounded");
        }
        cc.Move(Vector3.down * downVelocity * Time.deltaTime);

        Rotate();
        CameraRotate();
        CheckInput();
    }
}
