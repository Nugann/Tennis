using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float speed;
    public float direction;
    public float adjustSpeed;
    public Transform upperLimit;
    public Transform lowerLimit;
    public int playerNumber;
    public bool isAI;
    public BallController theBall;
        // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAI)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, theBall.transform.position.y, transform.position.z),speed * Time.deltaTime);
        }
        else {
            if(playerNumber == 1)
            {
                if(Input.GetKey(KeyCode.W)){
                    transform.position = new Vector3(transform.position.x,transform.position.y+(speed*Time.deltaTime),transform.position.z);
                    direction = 1;
                } else if(Input.GetKey(KeyCode.S)){
                    transform.position = new Vector3(transform.position.x,transform.position.y-(speed*Time.deltaTime),transform.position.z);
                    direction = -1;
                } else {
                    direction = 0;
                }
            }
            else if(playerNumber == 2)
            {
                if(Input.GetKey(KeyCode.UpArrow)){
                    transform.position = new Vector3(transform.position.x,transform.position.y+(speed*Time.deltaTime),transform.position.z);
                    direction = 1;
                } else if(Input.GetKey(KeyCode.DownArrow)){
                    transform.position = new Vector3(transform.position.x,transform.position.y-(speed*Time.deltaTime),transform.position.z);
                    direction = -1;
                } else {
                    direction = 0;
                }            
            }    
            }    
        if(transform.position.y > upperLimit.position.y)
        {
            transform.position = new Vector3(transform.position.x,upperLimit.position.y,transform.position.z);
        }
        else if(transform.position.y < lowerLimit.position.y)
        {
            transform.position = new Vector3(transform.position.x,lowerLimit.position.y,transform.position.z);
        }
    
    }
    void OnCollisionExit2D(Collision2D other){
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f,other.rigidbody.velocity.y + (direction*adjustSpeed));
        Debug.Log(other.rigidbody.velocity);
    }
}
