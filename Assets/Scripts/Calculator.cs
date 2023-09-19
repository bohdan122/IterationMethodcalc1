using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{

    [System.Serializable]
    public class serializableClass
    {
        public List<double> sampleList = new List<double>();
    }
    private List<double> B = new List<double>();
    public List<serializableClass> A = new List<serializableClass>();
    public List<double> X = new List<double>();
    private void Start()
    {

        A.Add(new serializableClass());
        A.Add(new serializableClass());
        A.Add(new serializableClass());

        A[0].sampleList.Add(0);
        A[0].sampleList.Add(0);
        A[0].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[2].sampleList.Add(0);
        A[2].sampleList.Add(0);
        A[2].sampleList.Add(0);


        for (int j = 0; j < 3; j++)
        {
            B.Add(default(double));
        }
        for (int j = 0; j < 3; j++)
        {
            X.Add(default(double));
        }



    }

    public void Getnumber(int x, int y, double number)
    {
        if (x==3)
        {
            B[y] = number;
            X[y] = number;
        }
        else
        {
            A[x].sampleList[y] = number;
        }
    }


    private List<double> Multi(List<serializableClass> matrix1, List<double> matrix2)
    {
        List<double> result = new List<double>();

        for (int i = 0; i < matrix2.Count; i++)
        {
            result.Add(matrix1[i].sampleList[0] * matrix2[0] + matrix1[i].sampleList[1] * matrix2[1] + matrix1[i].sampleList[2] * matrix2[2]);
        }

        return result;
    }



    private List<double> Plus(List<double> matrix1, List<double> matrix2)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < matrix2.Count; i++)
        {
            result.Add(matrix1[i] + matrix2[i]);
        }

        return result;
    }
    public void itrerationMethod( int Count)
    {


        List<double> X = B;
        for (int i = 0; i < Count; i++)
        {
            X = Plus(B, Multi(A, X));
        }

        for (int i = 0; i < X.Count; i++)
        {
            Debug.Log(X[i].ToString());
        }
    }

    public void seidelMethod( int Count)
    {
        
        for(int i = 0; i < X.Count; i++)
        {
            X[i] = B[i];
        }

        for (int h = 0; h < Count; h++)
        {
            for (int i = 0; i < X.Count; i++)
            {
                X[i] = B[i] + (A[i].sampleList[0] * X[0] + A[i].sampleList[1] * X[1] + A[i].sampleList[2] * X[2]);
            }

        }
        for (int i = 0; i < X.Count; i++)
        {
            Debug.Log(X[i].ToString());
        }
        
    }
}
