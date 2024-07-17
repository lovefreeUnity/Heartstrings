using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portalManager : MonoBehaviour
{
    public Transform exitPotal;
    public Vector3 vector3;
    public Image fadeInImage;
    float time = 0f;
    float F_time = 0.5f;


    IEnumerator FadeFlow(Collider2D collider2D){
        PlayerController player = collider2D.gameObject.GetComponent<PlayerController>();
        fadeInImage.gameObject.SetActive(true);
        player.isMoveable = false;
        time = 0;
        Color alpha = fadeInImage.color;
        while(alpha.a < 1f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            fadeInImage.color = alpha;
            yield return null; 
        }
        time = 0;
        collider2D.transform.position = exitPotal.position + vector3; 
        yield return new WaitForSeconds(1f);
        while(alpha.a > 0f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            fadeInImage.color = alpha;
            yield return null;
        }
        fadeInImage.gameObject.SetActive(false);
        player.isMoveable = true;
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.tag == "Player"){
            StartCoroutine(FadeFlow(collider2D));
        }
    }
}
