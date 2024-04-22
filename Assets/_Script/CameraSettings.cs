using UnityEditor;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    // Fattore di riduzione della sensibilità del giroscopio
    [SerializeField]private float gyroSensitivity = 0.1f;

    // Variabili per il filtro del movimento del giroscopio
    private Vector3 rotationRate;
    [SerializeField] float lowPassFilterFactor = 0.1f;

    private void Start()
    {
        cameraContainer = new GameObject("CameraContainer");
        cameraContainer.transform.position = this.transform.position;
        this.transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            // Inizializza la velocità di rotazione del giroscopio
            rotationRate = gyro.rotationRate;

            return true;
        }

        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            // Applica il filtro al movimento del giroscopio
            rotationRate = Vector3.Lerp(rotationRate, gyro.rotationRate, lowPassFilterFactor);

            // Riduci la sensibilità del giroscopio e applica la rotazione
            Vector3 gyroRotation = rotationRate * gyroSensitivity;
            transform.localRotation = gyro.attitude * rot * Quaternion.Euler(-gyroRotation.x, -gyroRotation.y, gyroRotation.z);
        }
    }
}
