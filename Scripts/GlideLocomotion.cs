using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideLocomotion : MonoBehaviour
{
    public Transform rigRoot;
    public Transform trackedTransform;
    public float velocity = 2f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        if (rigRoot == null)
        {
            rigRoot = transform;
        }
    }

    private void Update()
    {
        float forward = Input.GetAxis("XRI_Left_Primary2DAxis_Vertical");
        if (forward != 0f)
        {
            Vector3 moveDirection = Vector3.forward;
            if(trackedTransform != null)
            {
                moveDirection = trackedTransform.forward;
                moveDirection.y = 0f;
            }
            moveDirection *= -forward * velocity * Time.deltaTime;
            rigRoot.Translate(moveDirection);
        }

        float slew = Input.GetAxis("XRI_Left_Primary2DAxis_Horizontal");
        if(slew != 0f)
        {
            Vector2 moveDirection = Vector3.right;
            if(trackedTransform != null)
            {
                moveDirection = trackedTransform.right;
                moveDirection.y = 0f;
            }
            moveDirection *= slew * velocity * Time.deltaTime;
            rigRoot.Translate(moveDirection);
        }

        if(trackedTransform == null)
        {
            float sideways = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");
            if (sideways != 0f)
            {
                float rotation = sideways * rotationSpeed * Time.deltaTime;
                rigRoot.Rotate(0, rotation, 0);
            }
        }
    }
}
