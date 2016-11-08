using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour
{
    enum BallState { }

    public float gravity = (float)-0.001;
    public float ySpeedMax = 500;
    public float bounceRate = 1000;

    private RectTransform t;
    private float radius;

    private float _xSpeed = 0;
    private float _ySpeed = 0;

    void Start()
    {
        t = GetComponent<RectTransform>();
        radius = GetComponent<CircleCollider2D>().radius; 
    }

    void FixedUpdate()
    {
        // Debug
        if (Input.GetKey(KeyCode.LeftArrow)) _xSpeed -= 100;
        if (Input.GetKey(KeyCode.RightArrow)) _xSpeed += 100;

        // Predict Collision
        /*
        RaycastHit hitInfo = new RaycastHit();
        Vector3 direction = new Vector3(_xSpeed, _ySpeed, 0f);
        Ray speedRay = new Ray(t.position, direction);
        float maxDistance = Mathf.Sqrt((_xSpeed * Time.deltaTime) * (_xSpeed * Time.deltaTime) + (_ySpeed * Time.deltaTime) * (_ySpeed * Time.deltaTime));
        if (Physics.SphereCast(t.position, 100, direction, out hitInfo, maxDistance))
        {
            if (hitInfo.transform.gameObject.CompareTag("Wall")) _xSpeed = -_xSpeed;
            if (hitInfo.transform.gameObject.CompareTag("Floor")) _ySpeed = -_ySpeed;
        }
        */
        if (Mathf.Abs(_ySpeed) >= ySpeedMax) _ySpeed = Mathf.Sign(_ySpeed) * ySpeedMax;


        float newPosX = t.position.x + (_xSpeed * Time.deltaTime);
        float newPosY = t.position.y + (_ySpeed * Time.deltaTime);

        _ySpeed += gravity;
        t.position = new Vector3(newPosX, newPosY, 0f);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Before : " + _ySpeed);
        if (collision.gameObject.CompareTag("Floor")) _ySpeed = -_ySpeed;
        if (collision.gameObject.CompareTag("Pika")) _ySpeed = -_ySpeed + bounceRate;
        if (collision.gameObject.CompareTag("Wall")) _xSpeed = -_xSpeed;
        Debug.Log("After : " + _ySpeed);
    }

}
