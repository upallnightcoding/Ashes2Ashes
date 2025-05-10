using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2A
{
    public class HeroCntrl : MonoBehaviour
    {
        [SerializeField] private PlayerInputCntrl playerInputCntrl;
        [SerializeField] private float rotationSpeed = 400.0f;
        [SerializeField] private GameObject mainCamera;

        private Animator animator;

        private Vector3 moveDirection;
        private Vector3 playerDirection;

        private Vector2 playerMove;

        private int speedId;

        // Start is called before the first frame update
        void Start()
        {
            //animator = GetComponentInChildren<Animator>();
            animator = GetComponent<Animator>();

            speedId = Animator.StringToHash("move");
        }

        // Update is called once per frame
        void Update()
        {
            playerMove = playerInputCntrl.Move;

            Move(Time.deltaTime);
        }

        private void Move(float dt)
        {
            playerDirection.x = playerMove.x; // Horizontal
            playerDirection.y = 0.0f;
            playerDirection.z = playerMove.y; // Vertical

            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);

            animator.SetFloat(speedId, inputMagnitude, 0.05f, dt);

            moveDirection = mainCamera.transform.TransformDirection(playerDirection);
            moveDirection.y = 0.0f;

            if (moveDirection != Vector3.zero)
            {
                moveDirection.Normalize();

                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * dt);
            }
        }

        private void xxxMove(float dt)
        {
            moveDirection.x = playerMove.x; // Horizontal
            moveDirection.y = 0.0f;
            moveDirection.z = playerMove.y; // Vertical

            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);

            Debug.Log($"inputMagnitude: {inputMagnitude}");

            animator.SetFloat(speedId, inputMagnitude);
            //animator.SetFloat(speedId, inputMagnitude, 0.05f, dt);
            Debug.Log($"GetFloat: {animator.GetFloat(speedId)}");

            if (moveDirection != Vector3.zero)
            {
                moveDirection.Normalize();

                float targetRotation = mainCamera.transform.rotation.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0.0f, targetRotation, 0.0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * dt);
            }
        }

        /*private void Move(float dt)
        {
            float targetRotation = mainCamera.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0.0f, targetRotation, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            float moveSpeed = inputCntrl.Run ? runSpeed : walkSpeed;
            currentVelocity.x = Mathf.Lerp(currentVelocity.x, inputCntrl.Move.x * moveSpeed, animationBlendSpeed * Time.deltaTime);
            currentVelocity.y = Mathf.Lerp(currentVelocity.y, inputCntrl.Move.y * moveSpeed, animationBlendSpeed * Time.deltaTime);

            animator.SetFloat(xVelocityId, currentVelocity.x);
            animator.SetFloat(yVelocityId, currentVelocity.y);
        }*/
    }
}

