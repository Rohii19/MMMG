using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMovementController : MonoBehaviour
{
    public Joystick joystick;   
    public FixedTouchField fixedTouchField; 
   
    private RigidbodyFirstPersonController rigidBodyController;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyController = GetComponent<RigidbodyFirstPersonController>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    void FixedUpdate()
    {
        rigidBodyController.joystickInputAxis.x = joystick.Horizontal;
        rigidBodyController.joystickInputAxis.y = joystick.Vertical;
        rigidBodyController.mouseLook.lookInputAxis = fixedTouchField.TouchDist;       
    }
}
