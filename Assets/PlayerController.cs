using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rigid;
    float speed = 8f;
    Vector3 dirVec;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * speed;
Debug.Log(movement);
        rigid.velocity = new Vector2(movement.x, movement.y);

        if(moveY == 1){
            dirVec = Vector3.forward; 
        }else if(moveY == -1){
            dirVec = Vector3.back; 
        }else if(moveX == 1){
            dirVec = Vector3.right; 
        }else if(moveX == -1){
            dirVec = Vector3.left; 
        }
        
        if (Input.GetKeyDown(KeyCode.F) && Physics.Raycast(rigid.position, dirVec, out RaycastHit raycastHit,1.5f))
        {
            GameObject hitObject = raycastHit.collider.gameObject;
        }

    }
}
