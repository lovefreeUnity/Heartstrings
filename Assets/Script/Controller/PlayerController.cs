using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rigid;
    float speed = 8f;
    Vector3 dirVec;
    SpriteRenderer spriteRenderer;
    Animator animator;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move(); // 이동
        Interaction();  // 상호작용
    }

    void Move(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * speed;

        rigid.velocity = new Vector2(movement.x, movement.y);

        if(moveY == 1){
            dirVec = Vector2.up; 
            animator.SetBool("isBack",true);
            animator.SetBool("isWalking",false);
        }if(moveY == -1){
            dirVec = Vector2.down; 
            animator.SetBool("isBack",false);
            animator.SetBool("isWalking",false);
        } if(moveX == 1){
            dirVec = Vector2.right; 
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking",true);
            animator.SetBool("isBack",false);
        } if(moveX == -1){
            dirVec = Vector2.left; 
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking",true);
            animator.SetBool("isBack",false);
        }
    }

    void Interaction() {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVec, 1.5f);
        if (Input.GetKeyDown(KeyCode.F) && hit)
        {
            // GameObject hitObject = hit.collider.gameObject;
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
