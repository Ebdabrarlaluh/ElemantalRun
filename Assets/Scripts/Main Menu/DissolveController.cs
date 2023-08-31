using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float dissolveAmount;
    public float dissolveSpeed;
    public bool isDissolving;
    private Material mat;

    [ColorUsageAttribute(true,true)]
    public Color inColor;

    [ColorUsageAttribute(true, true)]
    public Color outColor;

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
            DissolveOut(dissolveSpeed, outColor);
        }

        if (!isDissolving)
        {
            DissolveIn(dissolveSpeed, inColor);
        }

        mat.SetFloat("_DissolveAmount", dissolveAmount);
    }

    public void DissolveOut(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
            if (dissolveAmount > 0)
                dissolveAmount -= speed * Time.deltaTime;
    }

    public void DissolveIn(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
        if (dissolveAmount < 1)
            dissolveAmount += speed * Time.deltaTime;
    }
}
