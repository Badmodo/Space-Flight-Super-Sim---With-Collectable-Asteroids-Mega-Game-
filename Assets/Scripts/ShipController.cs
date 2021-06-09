using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f, boost = 200f, unBoosted = 25f;
    private float activeForwardSpeed, activeStrafeSpeed, ActioveHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public KeyCode key = KeyCode.LeftShift;

    public float lookRotateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    public GameObject Thrusters;
    public GameObject Boost;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    Animator animator;

    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;

        animator = GetComponent<Animator>();
    }

    void Update()
    {       
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        ActioveHoverSpeed = Mathf.Lerp(ActioveHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        if (Input.GetKeyDown(key))
        {
            forwardSpeed = (forwardSpeed + boost);
        }

        if (Input.GetKeyUp(key))
        {
            forwardSpeed = unBoosted;
        }           

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * ActioveHoverSpeed * Time.deltaTime;

        if (Input.GetButtonDown("forward"))
        {
            Thrusters.SetActive(true);
        }

        if (Input.GetButtonUp("forward"))
        {
            Thrusters.SetActive(false);
        }

        if (Input.GetButtonDown("boost"))
        {
            Boost.SetActive(true);
        }

        if (Input.GetButtonUp("boost"))
        {
            Boost.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            animator.enabled = true;
        }        
    }
}
