using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private List<double> B = new List<double>();
    private List<List<double>> A;
    private void Start()
    {

        A = new List<List<double>>(3);

        for (int i = 0; i < 3; i++)
        {
            A.Add(new List<double>(3));

            for (int j = 0; j < 3; j++)
            {
                A[i].Add(default(double));
            }
        }
        B.Add(1.2);
        B.Add(1.3);
        B.Add(1.4);
        A[0][0] = 0;
        A[0][1] = -0.1;
        A[0][2] = -0.1;
        A[1][0] = -0.1;
        A[1][1] = 0;
        A[1][2] = -0.2;
        A[2][0] = -0.2;
        A[2][1] = -0.2;
        A[2][2] = 0;

        List<double> result = seidelMethod(B, A, 10);
        for (int i = 0; i < result.Count; i++)
        {
            Debug.Log(result[i].ToString());
        }

    }


    private List<double> Multi(List<List<double>> matrix1, List<double> matrix2)
    {
        List<double> result = new List<double>();

        for (int i = 0; i < matrix2.Count; i++)
        {
            result.Add(matrix1[i][0] * matrix2[0] + matrix1[i][1] * matrix2[1] + matrix1[i][2] * matrix2[2]);
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
    private List<double> itrerationMethod(List<double> B, List<List<double>> A, int Count)
    {


        List<double> X = B;
        for (int i = 0; i < Count; i++)
        {
            X = Plus(B, Multi(A, X));
        }

        return X;
    }

    private List<double> seidelMethod(List<double> B, List<List<double>> A, int Count)
    {
        List<double> X = new List<double>(B);


        for (int h = 0; h < Count; h++)
        {
            for (int i = 0; i < X.Count; i++)
            {
                X[i] = B[i] + (A[i][0] * X[0] + A[i][1] * X[1] + A[i][2] * X[2]);
            }

        }
        return X;
    }
}
