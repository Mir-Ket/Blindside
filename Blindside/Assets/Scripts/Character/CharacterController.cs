
using UnityEngine;


public class CharacterController : MonoBehaviour
{

    private Ray currentRay;
    [SerializeField] private float raycastDistance;

    [Header("Hareket Ayarlar�")]
    public float moveSpeed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [Header("Kamera Ayarlar�")]
    public float mouseSensitivity = 2f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float lookXLimit = 80.0f;

    [Header("Zemin Kontrol�")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    // �zel De�i�kenler
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isGrounded;
    private bool canJump = true;
    private float xRotation = 0f;

    void Awake()
    {
        // Rigidbody bile�enini al
        rb = GetComponent<Rigidbody>();

        // Fareyi ekran�n ortas�na kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Girdileri her frame'de al
        GetInput();
        // Kamera hareketini her frame'de yap (daha ak�c� hissettirir)
        HandleLook();
        RaycastController();
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleMovement();
    }

    private void RaycastController()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.TryGetComponent(out IInterectable interectableObject))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interectableObject.Interact();
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (playerCamera != null)
        {
            Gizmos.color = Color.green;

            // D�ZELTME: �izgiyi kameran�n pozisyonundan ba�lat�p, bakt��� y�ne do�ru raycastDistance kadar �iziyoruz.
            Vector3 endPoint = playerCamera.transform.position + playerCamera.transform.forward * raycastDistance;
            Gizmos.DrawLine(playerCamera.transform.position, endPoint);
        }
    }
    /// Kullan�c�dan klavye ve fare girdilerini al�r.
    private void GetInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Fareden gelen girdiler
        lookInput.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        lookInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (Input.GetButtonDown("Jump") && canJump && isGrounded)
        {
            Jump();
        }
    }

    /// Karakterin hareketini y�netir.
    private void HandleMovement()
    {
        // Karakterin bakt��� y�ne g�re hareket vekt�r� olu�tur
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        // Y�ksekli�i koruyarak h�z� ayarla
        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    // Fare hareketine g�re kamera ve karakter rotasyonunu y�netir.
    private void HandleLook()
    {
        // Dikey (yukar�/a�a��) rotasyon
        xRotation -= lookInput.y;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit); // Rotasyonu limitler
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yatay (sa�a/sola) rotasyon
        transform.Rotate(Vector3.up * lookInput.x);
    }


    // Karakterin z�plamas�n� sa�lar.
    private void Jump()
    {
        // Z�plarken dikey h�z� s�f�rlayarak daha tutarl� z�plama sa�lar
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        // Yukar� y�nde ani bir kuvvet uygula
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   // Karakterin zeminde olup olmad���n� kontrol eder.
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    //Edit�rde zemin kontrol alan�n� g�rmek i�in
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
