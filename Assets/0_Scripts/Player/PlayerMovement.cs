using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveAmount;
    [SerializeField] private float jumpForce;
    
    
    
    [SerializeField] private LaneManager lanes;
    
    public void ChangeLane(int direction)
    {
        if (lanes.IsLaneChangeAllowed(direction))
        {
            Debug.Log("ENTRA");
            Vector3 target = new Vector3(moveAmount * direction, 0, 0);
            transform.position += target;//Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
            lanes.SetCurrentLane(lanes.currentLane += 1 * direction);
        } else Debug.Log("NOP");
    }

    void Jump()
    {
        
    }

    void Slide()
    {
        
    }
}
