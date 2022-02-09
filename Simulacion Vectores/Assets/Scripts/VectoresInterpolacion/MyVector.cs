using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2D vector class.
/// </summary>
[System.Serializable]
public class MyVector
{
    public float X;
    public float Y;

    public MyVector (float x,float y)
    {
        this.X = x;
        this.Y = y;
    }

    public MyVector Add(MyVector vector)
    {
        /* float x = this.X + vector.X;
         float y = this.Y + vector.Y;
         return new MyVector(x, y);*/
        return this + vector; //Al definir el operador + en el vector es posible implementar una suma mas simple.
    }
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.X + b.X, a.Y + b.Y);
    }

    public MyVector Sub(MyVector vector)
    {
        /*float x = this.X - vector.X;
        float y = this.Y - vector.Y;
        return new MyVector(x, y);*/
        return vector - this;
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.X - b.X, a.Y - b.Y);
    }

    public MyVector MagMul(float mag)
    {
        float x = this.X * mag;
        float y = this.Y * mag;
        return new MyVector(x, y);
    }
    public static MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.X * b, a.Y * b);
    }
    public static MyVector operator /(MyVector a, float b)
    {
        if (b != 0) return new MyVector(a.X / b, a.Y / b);
        else return null;
    }

    public float PointMul(MyVector vector)
    {
        float multi = this.X * vector.X + this.Y * vector.Y;
        return multi;
    }

    public Vector3 CrossMul(MyVector vector)
    {

        Vector3 multi = new Vector3(0, 0, (this.X * vector.Y) - (this.Y * vector.X));
        return multi;
    }

    public float Mag()
    {
        float magnitud = Mathf.Sqrt(this.X * this.X + this.Y * this.Y);
        return magnitud;
    }

    public MyVector Normalize()
    {
        float mag = this.Mag();
        MyVector normalized = this.MagMul(1 / mag);

        //float x = this.X / mag;        
        //float y = this.Y / mag;
        //MyVector normalized = new MyVector(x,y);

        return normalized;
    }

    public MyVector Lerp(MyVector vector1, float k)
    {
        return this + ((vector1 - this) * k);
    }

    public void Draw(Color color)
    {
        Vector2 vector = new Vector2(X, Y);
        Debug.DrawLine(Vector3.zero, vector, color);
    }
    public void Draw(MyVector firstVector, Color color)
    {
        Vector2 tail = new Vector2(firstVector.X, firstVector.Y);
        Vector2 head = new Vector2(X, Y);
        Debug.DrawLine(tail, head, color);
    }

    public override string ToString()
    {
        return ("(" + X + " , " + Y + ")");
    }
}
