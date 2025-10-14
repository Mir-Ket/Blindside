
using UnityEngine;


public class CharacterController : MonoBehaviour
{

    private Ray currentRay;
    [SerializeField] private float raycastDistance;

    [Header("Hareket Ayarlarý")]
    public float moveSpeed = 5f;

    [SerializeField] private float jumpForce = 5f;

    [Header("Kamera Ayarlarý")]
    public float mouseSensitivity = 2f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float lookXLimit = 80.0f;

    [Header("Zemin Kontrolü")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    // Özel Deðiþkenler
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isGrounded;
    private bool canJump = true;
    private float xRotation = 0f;

    void Awake()
    {
        // Rigidbody bileþenini al
        rb = GetComponent<Rigidbody>();

        // Fareyi ekranýn ortasýna kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Girdileri her frame'de al
        GetInput();
        // Kamera hareketini her frame'de yap (daha akýcý hissettirir)
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

            // DÜZELTME: Çizgiyi kameranýn pozisyonundan baþlatýp, baktýðý yöne doðru raycastDistance kadar çiziyoruz.
            Vector3 endPoint = playerCamera.transform.position + playerCamera.transform.forward * raycastDistance;
            Gizmos.DrawLine(playerCamera.transform.position, endPoint);
        }
    }
    /// Kullanýcýdan klavye ve fare girdilerini alýr.
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

    /// Karakterin hareketini yönetir.
    private void HandleMovement()
    {
        // Karakterin baktýðý yöne göre hareket vektörü oluþtur
        Vector3 moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;

        // Yüksekliði koruyarak hýzý ayarla
        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    // Fare hareketine göre kamera ve karakter rotasyonunu yönetir.
    private void HandleLook()
    {
        // Dikey (yukarý/aþaðý) rotasyon
        xRotation -= lookInput.y;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit); // Rotasyonu limitler
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yatay (saða/sola) rotasyon
        transform.Rotate(Vector3.up * lookInput.x);
    }


    // Karakterin zýplamasýný saðlar.
    private void Jump()
    {
        // Zýplarken dikey hýzý sýfýrlayarak daha tutarlý zýplama saðlar
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        // Yukarý yönde ani bir kuvvet uygula
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   // Karakterin zeminde olup olmadýðýný kontrol eder.
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    //Editörde zemin kontrol alanýný görmek için
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
