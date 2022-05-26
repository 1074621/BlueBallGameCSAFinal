using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    public float ogSpeed = 0f;
    public float newSpeed = 0f;
    public float collectables = 0f;
    public float goUp = 0f;
    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    public GameObject starObject;
    public GameObject pausedMenuObject;
    public GameObject camera;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private static bool paused;

    private bool coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        speed = ogSpeed;

        SetCountText(0);
        winTextObject.SetActive(false);
        
        paused = false;
    }

    // Movement Valyes
    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Pick Up Count
    void SetCountText(int level) 
    {
        countText.text = "Coins: " + count.ToString() + " / " + collectables;
        if (count == collectables)
        {
            coinsCollected = true;
        }
        else 
        {
            coinsCollected = false;
        }
    }

    void OnCancel() 
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void OnStop()
    {
        rb.velocity = new Vector3();
    }


    // Movement and Death
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);

        rb.AddForce(movement * speed);

        if(rb.position.y < -10f) {
            ButtonScripts.Retry();
        }
    }

    // Colliders
    //Pick Up Checks
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (other.gameObject.CompareTag("End"))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            this.enabled = false;
            this.gameObject.GetComponent <MeshRenderer>().enabled = false;
            camera.GetComponent<CameraController>().enabled = false;
            Cursor.visible = true;
            winTextObject.SetActive(true);
            if (coinsCollected) 
            {
                starObject.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Grav")) 
        {
            other.gameObject.SetActive(false);
            rb.AddForce(Vector3.up * goUp);
        }
    }

    //Danger Object Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Danger"))
        {
            ButtonScripts.Retry();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Speed")) 
        {
            speed = newSpeed;
        }
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            speed = ogSpeed;
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pausedMenuObject.gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        pausedMenuObject.gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }
}
