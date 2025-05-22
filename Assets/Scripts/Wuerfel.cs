using UnityEngine;
using UnityEngine.Categorization;

public class Wuerfel : MonoBehaviour
{
    void Update()
    {
        float xNeu = transform.position.x;
        float zNeu = transform.position.z;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xNeu++;
            if (xNeu > 2) xNeu = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xNeu--;
            if (xNeu < -2) xNeu = -2;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            zNeu++;
            if (zNeu > 2) zNeu = 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            zNeu--;
            if (zNeu < -2) zNeu = -2;
        }

        transform.position = new Vector3(xNeu, transform.position.y, zNeu);
    }
}
