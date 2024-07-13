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
    float F_time = 1f;


    IEnumerator FadeFlow(){
        fadeInImage.gameObject.SetActive(true);
        time = 0;
        Color alpha = fadeInImage.color;
        while(alpha.a < 1f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            fadeInImage.color = alpha;
        }
        time = 0;
        yield return new WaitForSeconds(1f);
        while(alpha.a > 0f){
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1,0,time);
            fadeInImage.color = alpha;
        }
        fadeInImage.gameObject.SetActive(false);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.tag == "Player"){
            collider2D.transform.position = exitPotal.position + vector3; 
            StartCoroutine(FadeFlow());
        }
    }
}
