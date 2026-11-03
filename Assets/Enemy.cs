using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed;

    public float distance;

    public LineRenderer lineofsight;
    public Gradient redcolour;
    public Gradient greencolour;

    void Start ()
    {
        Physics2D.queriesStartInColliders = false;
    }
    public void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            lineofsight.SetPosition(1, hitInfo.point);
            lineofsight.colorGradient = redcolour;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);

            lineofsight.SetPosition(1, transform.position + transform.right * distance);
            lineofsight.colorGradient = greencolour;
        }

        lineofsight.SetPosition(0, transform.position);
    }

}
