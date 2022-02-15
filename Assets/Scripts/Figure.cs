using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Figure : MonoBehaviour
{
    private enum FigureType
    {
        Circle,
        Cube,
        Triangle
    }
    [SerializeField] private FigureType _figureType;
    public int Size = 1;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        transform.localScale *= Size;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_figureType == FigureType.Circle)
            Gizmos.DrawWireSphere(transform.position, Size * gameObject.GetComponent<RectTransform>().sizeDelta.x/2);
        if (_figureType == FigureType.Cube)
            Gizmos.DrawWireCube(transform.position, new Vector3(Size * gameObject.GetComponent<RectTransform>().sizeDelta.x, Size * gameObject.GetComponent<RectTransform>().sizeDelta.x, Size * gameObject.GetComponent<RectTransform>().sizeDelta.x));
    }

    public void ReduceSize()
    {
        if (Size > 1)
        {
            transform.localScale /= Size;
            Size -= 1;
            transform.localScale *= Size;
        }
    }
}
