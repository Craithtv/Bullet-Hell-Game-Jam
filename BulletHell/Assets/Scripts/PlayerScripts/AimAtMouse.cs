using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{

    Vector3 mousePos;
    Vector2 direction;
    public GameObject player;
    float objDistFromPlayer;
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = player.transform.position;
        objDistFromPlayer = player.GetComponent<AttackTest>().GetAttackRange();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = mousePos - player.transform.position;

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        float distance = difference.magnitude;
        direction = difference / distance;
        direction.Normalize();

        gameObject.transform.position = player.transform.position + new Vector3(direction.x, direction.y) * objDistFromPlayer;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
