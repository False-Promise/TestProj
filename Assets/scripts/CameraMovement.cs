using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;         // Персонаж
    public Vector3 offset;           // Відступ камери
    public float sensitivity = 5f;   // Чутливість миші
    public float distance = 5f;      // Відстань до персонажа
    public float minY = -35f;        // Мінімальний кут нахилу камери
    public float maxY = 60f;         // Максимальний кут нахилу камери

    private float rotX = 0f;         // Вісь X для обертання
    private float rotY = 0f;         // Вісь Y для обертання

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Сховати курсор
    }

    void LateUpdate()
    {
        // Отримання руху миші
        rotX += Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, minY, maxY);

        // Обертання камери навколо персонажа
        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance) + offset;

        transform.position = position;
        transform.LookAt(target);
    }
}
