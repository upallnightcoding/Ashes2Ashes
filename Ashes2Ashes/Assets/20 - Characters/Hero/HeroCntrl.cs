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
        [SerializeField] private float dashSpeed = 3.0f;
        [SerializeField] private float dashDuration = 0.5f;
        [SerializeField] private Transform triggerPoint;

        private Animator animator;

        private Vector3 moveDirection;
        private Vector3 playerDirection;

        private Vector2 playerMove;

        private int speedId;
        private int dashSpeedId;

        private bool inDashMode = false;

        private SpellCntrl spellCntrl;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            spellCntrl = GetComponent<SpellCntrl>();

            speedId = Animator.StringToHash("move");
            dashSpeedId = Animator.StringToHash("dashspeed");
        }

        // Update is called once per frame
        void Update()
        {
            playerMove = playerInputCntrl.Move;

            Move(Time.deltaTime);

            if (playerInputCntrl.Dash && !inDashMode)
            {
                Dash();
            }

            if (playerInputCntrl.Fire)
            {
                Fire();
            }

            if (playerInputCntrl.AttackLight)
            {
                playerInputCntrl.AttackLight = false;
                spellCntrl.FireLightAttack(triggerPoint.position, transform.forward);

            }
        }

        private void Fire()
        {
            spellCntrl.FireLightAttack(triggerPoint.position, transform.forward);
            playerInputCntrl.Fire = false;
        }

        /**
         * Dash() - Turns on the dash mode and increases the animation to the
         * dash speed.  The non-blocking co-routine is then invoked to start 
         * the timers on the dash.
         */
        private void Dash()
        {
            inDashMode = true;
            animator.SetFloat(dashSpeedId, dashSpeed);

            StartCoroutine(DashExec());
        }

        private IEnumerator DashExec()
        {
            yield return new WaitForSeconds(dashDuration);

            playerInputCntrl.Dash = false;
            animator.SetFloat(dashSpeedId, 1.0f);
            inDashMode = false;
        }

        /**
         * Move() - 
         */
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

