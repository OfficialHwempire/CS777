using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PendulumMoveController : MonoBehaviour
{
    [SerializeField]
    public  float nodeSpeed=5f;
    private int nodeDirection=1;
    [SerializeField]
    private float backgroundWidth = 20f;
    private SpriteRenderer backGroundSpriteRenderer;

    public float current_count =0;
    
    public float max_count = 100;

    private Vector3 originPos = new Vector3(0,0,0);
    

    // Start is called before the first frame update

private GameObject pendulum ;


void Start(){
    pendulum = this.gameObject;
    originPos = pendulum.transform.position;
    backGroundSpriteRenderer= transform.parent.GetComponent<SpriteRenderer>();
    if (    backGroundSpriteRenderer != null)
        {
            backgroundWidth = backGroundSpriteRenderer.bounds.size.x;
        }
        else
        {
            Debug.LogError("Background SpriteRenderer not found!");
        }
}
void Update(){
    move();
}
void move(){
     pendulum.transform.Translate(Vector3.right * nodeSpeed * Time.deltaTime*nodeDirection);
    current_count = ((pendulum.transform.position.x-originPos.x)/backgroundWidth)*max_count;
     
if(pendulum.transform.position.x - originPos.x >= backgroundWidth)
{
    nodeDirection =-1;
}
else if(pendulum.transform.position.x-originPos.x <=0)
{
    nodeDirection=1;
}

   
}

public void resetNode(){
    pendulum.transform.position = originPos;
    nodeDirection = 1;
    current_count
            = 0;
}

 
}
