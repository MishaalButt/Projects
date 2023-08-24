using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Rigidbody2D theRB;
    
    public float moveSpeed = 5f;
    public float mouseSensitivity = 1f;
    
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public Camera viewCam;

    public GameObject bulletImpact;
    public GameObject deadScreen;

    public int currentAmmo;
    public int maxAmmo = 400;
    public int currentHealth;
    public int maxHealth = 100;

    public Animator gunAnim;
    public Animator anim;

    public bool hasDied = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!hasDied)
        {
            // Player Movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            // Player Cursor Control (View Cam)
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);                // Quaternion = Vector4 specifically for rotation
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            // Shooting
            if (Input.GetMouseButtonDown(0))                                         // If they left click
            {
                if (currentAmmo > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));                  // Raycasting a line from the camera to where clicked
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))                                                   // if we do a raycast and information gets sent out to hit, then true
                    {
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if (hit.transform.tag == "Enemy" && hit.transform.parent.GetComponent<EnemyController>().health > 0)
                        {
                            hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                        }

                        AudioController.instance.PlayPistolFiring();
                    }
                    else
                    {
                        Debug.Log("I'm looking at nothin!");
                    }

                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                }
            }

            if(moveInput != Vector2.zero)
            {
                anim.SetBool("IsMoving", true);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }

        }

        

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);            // Play the death screen
            hasDied = true;
            currentHealth = 0;
            AudioController.instance.PlayPlayerDeath();
        }

        AudioController.instance.PlayPlayerInjure();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

}
