using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector2 rawInput;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    Vector2 minBoundary;
    Vector2 maxBoundary;
    Shooter shooter;
    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBoundary();
    }
    void Update()
    {
        Move();
    }
    void InitBoundary()
    {
        Camera mainCamera = Camera.main;
        minBoundary = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBoundary = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newpos = new Vector2();
        newpos.x = Mathf.Clamp(transform.position.x + delta.x, minBoundary.x + paddingLeft, maxBoundary.x - paddingRight);
        newpos.y = Mathf.Clamp(transform.position.y + delta.y, minBoundary.y + paddingBottom, maxBoundary.y - paddingTop);
        transform.position = newpos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}