using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    public LayerMask layerMask ;
    float countTime = 0;
    Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime++ * Time.deltaTime >= 15)
        {
            countTime = 0;
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        if (Physics2D.Raycast(laserFirePoint.position, laserFirePoint.position + laserFirePoint.up * defDistanceRay,99999.0f, layerMask))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, laserFirePoint.position + laserFirePoint.up * defDistanceRay, 99999.0f, layerMask);
            if (hit.collider.GetComponent<Player>())
            {
                hit.collider.GetComponent<Ship>().Hit(1000);
            }
            print(hit.collider.name);
        }
        FindObjectOfType<CameraShake>().Shake(0.1f, 0.1f);
        Draw2DRay(laserFirePoint.position, laserFirePoint.position + laserFirePoint.up * defDistanceRay);
        yield return new WaitForSeconds(0.1f);
        Draw2DRay(laserFirePoint.position, laserFirePoint.position);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
