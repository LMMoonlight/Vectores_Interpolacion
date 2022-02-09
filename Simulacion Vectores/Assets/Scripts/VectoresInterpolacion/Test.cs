using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{    
    //vectores para pruebas operadores
    MyVector vector1, vector2;
    MyVector vectorSum, vectorSub, vectorMagM, norm;
    MyVector vectorLineal;
    float PointM, mag;

    //Vectores para lerp
    [SerializeField] [Range(0, 1)] float range;
    [SerializeField] MyVector first;
    [SerializeField] MyVector second;
    MyVector res1, res2;

    private void Start()
    {
        vector1 = new MyVector(-1, 3);
        vector2 = new MyVector(2, 2);

        vectorSum = vector1.Add(vector2);
        vectorSub = vector1.Sub(vector2);
        vectorMagM = vector1.MagMul(2);
        PointM = vector1.PointMul(vector2);
        mag = vector1.Mag();
        norm = vector1.Normalize();

        Debug.Log("V1 + V2: " + vectorSum.ToString());
        Debug.Log("V1 - V2: " + vectorSub.ToString());
        Debug.Log("V1 * 2: " + vectorMagM.ToString());
        Debug.Log("v1 . v2: " + PointM);
        Debug.Log("La magnitud del vector 1 es: " + mag);
        Debug.Log("v1 normalizado: " + norm);

        
    }

    private void Update()
    {
        /*vector1.Draw(Color.red);
        vector2.Draw(Color.blue);

        vectorSub.Draw(Color.white);
        vector1.Draw(vector2, Color.green);*/

        first.Draw(Color.green);
        second.Draw(Color.red);

        res2 = second.Lerp(first, range);
        res2.Draw(Color.magenta);
       
        res1 = second.Sub(first).MagMul(range);
        res1.Draw(Color.cyan);
        second.Draw(res2, Color.yellow);
    }
}
