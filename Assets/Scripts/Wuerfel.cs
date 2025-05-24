using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Wuerfel : MonoBehaviour
{
    public GameObject wuerfelPrefab;
    List<GameObject> wuerfelListe;
    Rigidbody rb;
    bool ende = false;
    public Material[] mat = new Material[4];

    int punkte = 0;
    public TextMeshProUGUI punkteAnzeige;

    void Start()
    {
        wuerfelListe = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ende) return;
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

    void OnCollisionEnter(Collision coll)
    {
        Vector3 positionAlt = transform.position;
        if (positionAlt.y < 4)
        {
            Material materialAlt = GetComponent<MeshRenderer>().material;
            GetComponent<MeshRenderer>().material = mat[Random.Range(0, 4)];

            transform.position = new Vector3(0, 6, 0);
            rb.linearDamping *= 0.98f;

            Object objektVerweis = Instantiate(wuerfelPrefab, positionAlt, Quaternion.identity);

            GameObject spielObjektVerweis = (GameObject)objektVerweis;
            spielObjektVerweis.GetComponent<MeshRenderer>().material = materialAlt;
            wuerfelListe.Add(spielObjektVerweis);

            Pruefen();
        }
        else
        {
            ende = true;
        }
    }

    void Pruefen()
    {
        int zaehler = 0;
        for (int k = 0; k < wuerfelListe.Count; k++)
        {
            if (wuerfelListe[k].transform.position.y >= -2.75f && wuerfelListe[k].transform.position.y <= -2.35f)
            {
                zaehler++;
            }
        }

        if (zaehler == 25)
        {
            punkte++;
            punkteAnzeige.text = "Punkte: " + punkte;

            for (int k = wuerfelListe.Count - 1; k >= 0; k--)
            {
                if (wuerfelListe[k].transform.position.y >= -2.75f && wuerfelListe[k].transform.position.y <= -2.35f)
                {
                    Destroy(wuerfelListe[k]);
                    wuerfelListe.RemoveAt(k);
                }
            }
        }
    }
}
