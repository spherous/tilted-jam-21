using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryStartScipt : MonoBehaviour
{
    public Animator pirate;
    public Rigidbody rb_pirate;
    public GameObject rb_siren_head;
    public GameObject goStartPoint;
    public GameObject goJumpPoint;
    public float vel_pirate = 0.1f;
    public float start_walking_time = 2.0f;
    public float start_idle_time = 6.0f;
    public float start_jump_time = 8.0f;
    public float start_ride_time = 10.0f;
    public float start_game = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //pirate.SetTrigger("Idle");
        //rb_pirate = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > start_game)
        {
            SceneManager.LoadScene("AveaScene");
        }
        else if (Time.time > start_ride_time)
        {
            pirate.SetBool("riding", true);
            pirate.SetBool("falling", false);
        }
        else if (Time.time > start_jump_time)
        {
            pirate.SetBool("falling", true);
            float percent = (Time.time - start_jump_time) / (start_ride_time - start_jump_time);
            // Debug.Log(percent);
            rb_pirate.MovePosition(
               Vector3.Lerp(goJumpPoint.transform.position, rb_siren_head.transform.position, percent));
        }
        else if (Time.time > start_idle_time)
        {
            pirate.SetBool("walking", false);
        }
        else if (Time.time > start_walking_time)
        {
            pirate.SetBool("walking", true);
            Vector3 offset = Vector3.zero;
            offset.x = vel_pirate;
            //rb_pirate.MovePosition(rb_pirate.position + offset);
            float percent = (Time.time- start_walking_time) / (start_idle_time - start_walking_time);
            // Debug.Log(percent);
            rb_pirate.MovePosition(
                Vector3.Lerp(goStartPoint.transform.position, 
                             goJumpPoint.transform.position, 
                             percent));
        }
        else
        {
        }


    }
}
