using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    /*Vector2 minBounds;
    Vector2 maxBounds;*/


    [SerializeField] float moveSpeed = 10f;

    Shooter playerShooter;
    InputAction fireAction;

    void Start()
    {
        playerShooter = GetComponent<Shooter>();
        fireAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        movePlayer();
        FireShooter();
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    

    void movePlayer()
    {
        transform.position += new Vector3(moveInput.x * moveSpeed , moveInput.y * moveSpeed, 0) * Time.deltaTime;

    }

    /*void initBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }*/

}
