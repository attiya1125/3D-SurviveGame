using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI prompText;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)); // ������ ��, ������ �� 
            RaycastHit hit; // �ε��� ������Ʈ�� ����

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    // ������Ʈ ���
                    SetPromptText();
                }
            }
            else // ray�� ������Ʈ�� ������
            {
                curInteractGameObject = null;
                curInteractable = null;
                prompText.gameObject.SetActive(false);
            }
        }
    }
    private void SetPromptText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && curInteractable != null) // ������ ������ null�� �ƴҶ�
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            prompText.gameObject.SetActive(false);
        }

    }
}