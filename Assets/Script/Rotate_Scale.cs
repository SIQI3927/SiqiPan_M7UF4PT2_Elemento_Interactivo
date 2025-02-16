using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Scale : MonoBehaviour
{
    public float scaleTime;
    public float scale;
    public float rotateAmount;
    public float scaleAmount;

    private void Start()
    {
        StartCoroutine(ScaleObjecto());
    }

    void FixedUpdate()
    {
        transform.Rotate(0, rotateAmount, 0);
        transform.localScale += new Vector3(1f, 1f, 1f) * scale * scaleAmount;
    }

    private IEnumerator ScaleObjecto()
    {
        yield return new WaitForSeconds(scaleTime);
        scale = -scale;
        yield return ScaleObjecto();
    }

}
