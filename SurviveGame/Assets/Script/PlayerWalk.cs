using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : MonoBehaviour
{
    InputActionAsset InputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;

    private Vector2 moveAmt;
    private Vector2 lookAmt;

    Rigidbody rigid;

    [SerializeField]
    private float WalkSpeed = 5f;
    [SerializeField]
    private float JumpForce = 5f;
    [SerializeField]
    private float RotationSpeed = 5f;

    private void OnEnable()
    {
        InputActions.FindAction("Player").actionMap.Enable();
    }

    private void OnDisable()
    {
        InputActions.FindAction("Player").actionMap.Disable();
    }



    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();

        moveAction = InputActions.FindAction("Move");
        lookAction = InputActions.FindAction("Look");
        jumpAction = InputActions.FindAction("Jump");
    }


    private void Update()
    {
        moveAmt = moveAction.ReadValue<Vector2>();
        lookAmt = lookAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
        }
    }


    private void Jump()
    {

        rigid.AddForce(rigid.transform.up * JumpForce,ForceMode.Impulse);
    }


    private void FixedUpdate()
    {

        if (Camera.main == null)
        {
            return;
        }

        Vector3 camForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up); //카메라 앞쪽으로 이동
        Vector3 camRight = Vector3.ProjectOnPlane(Camera.main.transform.right , Vector3.right); //카메라 오른쪽으로 이동




    }


}
