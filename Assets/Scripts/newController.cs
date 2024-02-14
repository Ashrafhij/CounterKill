using UnityEngine;

public class newController : MonoBehaviour
{

    private newInputManager inputManager;
    public GameObject camerObject;
    private CharacterController characterController;

    public float jumpForce = 200f, movementSpeed = 1f ,gravityForce = -9.81f;
    [Range(0.1f, 5f)] public float mouseSensitivity = 1f;

    private bool pause = true;
    private Vector3 movement, gravity;


    private void Start()
    {
        inputManager = GetComponent<newInputManager>();
        characterController = GetComponent<CharacterController>();
    }


    private void FixedUpdate()
    {
        /*checkPause();
        if (pause) return;*/

        movement = transform.right * inputManager.horizontal + transform.forward * inputManager.vertical;
        characterController.Move(movement * movementSpeed * Time.deltaTime);
        gravity.y += gravityForce * Time.deltaTime;
        characterController.Move(gravity*Time.deltaTime);

        transform.localRotation *= Quaternion.Euler(0f, inputManager.yValue * mouseSensitivity, 0f);

        if (inputManager.xValue > 0 && camerObject.transform.localRotation.x > -0.7f)
            camerObject.transform.localRotation *= Quaternion.Euler(-inputManager.xValue * mouseSensitivity, 0f, 0f);

        if (inputManager.xValue < 0 && camerObject.transform.localRotation.x < 0.7f)
            camerObject.transform.localRotation *= Quaternion.Euler(-inputManager.xValue * mouseSensitivity, 0f, 0f);

    }
    public void Jump()
    {
        if (isGrounded())
            gravity.y = Mathf.Sqrt(jumpForce * -2 * gravityForce);
    }


    
    private bool isGrounded()
    {
        RaycastHit raycastHit;
        if (Physics.SphereCast(transform.position, characterController.radius * (1.0f - 0), Vector3.down, out raycastHit, ((characterController.height / 2f) - characterController.radius) + 0.15f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else return false;
    }
    

    private void OnGUI()
    {
        GUI.contentColor = Color.green;
    }

}
