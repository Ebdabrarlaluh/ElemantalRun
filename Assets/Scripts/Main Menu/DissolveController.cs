using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float dissolveAmount;
    public float dissolveSpeed;
    public bool isDissolving;
    private Material mat;   
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isDissolving = true;

        if (Input.GetKeyDown(KeyCode.M))
            isDissolving = false;

        if (isDissolving)
        {
            if (dissolveAmount > 0)
                dissolveAmount -= dissolveSpeed * Time.deltaTime;
        }

        if (!isDissolving)
        {
            if (dissolveAmount < 1)
                dissolveAmount += dissolveSpeed * Time.deltaTime;
        }

        mat.SetFloat("_DissolveAmount", dissolveAmount);
    }
}
