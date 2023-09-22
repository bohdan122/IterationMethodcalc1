using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
<<<<<<< Updated upstream
    private List<double> B = new List<double>();
    private List<List<double>> A;
=======

    [System.Serializable]
    public class serializableClass
    {
        public List<double> sampleList = new List<double>();
    }
    [SerializeField] private List<double> B = new List<double>();
    [SerializeField] private List<double> B_start = new List<double>();
    public List<serializableClass> A = new List<serializableClass>();
    public List<serializableClass> A_start = new List<serializableClass>();

    [SerializeField] public List<double> X = new List<double>();

    private double mistake;

    public int whatmethodoweusetellmepls = 0;

    [SerializeField] GameObject outManager;
    public void DoShit(int num)
    {
        whatmethodoweusetellmepls = num;
    }

    public void CalculateThishShit( int Count)
    {
        if (whatmethodoweusetellmepls == 0)
        {
            itrerationMethod(Count);
        }
        else
        {
            seidelMethod(Count);
        }

        for (int i = 0; i < X.Count; i++)
        {
            Debug.Log(X[i].ToString());
        }
        outManager.GetComponent<outputManageer>().outputNumbers(X);
    }




>>>>>>> Stashed changes
    private void Start()
    {

        A = new List<List<double>>(3);

<<<<<<< Updated upstream
        for (int i = 0; i < 3; i++)
=======
        A_start.Add(new serializableClass());
        A_start.Add(new serializableClass());
        A_start.Add(new serializableClass());

        A[0].sampleList.Add(0);
        A[0].sampleList.Add(0);
        A[0].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[1].sampleList.Add(0);
        A[2].sampleList.Add(0);
        A[2].sampleList.Add(0);
        A[2].sampleList.Add(0);

        A_start[0].sampleList.Add(0);
        A_start[0].sampleList.Add(0);
        A_start[0].sampleList.Add(0);
        A_start[1].sampleList.Add(0);
        A_start[1].sampleList.Add(0);
        A_start[1].sampleList.Add(0);
        A_start[2].sampleList.Add(0);
        A_start[2].sampleList.Add(0);
        A_start[2].sampleList.Add(0);


        for (int j = 0; j < 3; j++)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            Debug.Log(result[i].ToString());
=======
            B_start.Add(default(double));
        }
        for (int j = 0; j < 3; j++)
        {
            X.Add(default(double));
>>>>>>> Stashed changes
        }

    }

<<<<<<< Updated upstream
=======
    public void Getnumber(int x, int y, double number)
    {
        if (x == 4)
        {
            mistake = number;
        }
        if (x==3)
        {
            B_start[y] = number;
            B_start[y] = number;
        }
        else
        {
            A_start[x].sampleList[y] = number;
        }
    }
>>>>>>> Stashed changes

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
        transformMatrix();

<<<<<<< Updated upstream

        List<double> X = B;
=======
        
>>>>>>> Stashed changes
        for (int i = 0; i < Count; i++)
        {
            X = Plus(B, Multi(A, X));
        }

        return X;
    }
    void transformMatrix()
    {
        for(int i = 0;i < 3;i++) {
            double max = A_start[i].sampleList[i];
            for (int j = 0; j < 3; j++)
            {
                if(i==j)
                {
                    A[i].sampleList[j] = 0;
                    continue;
                }
                
                A[i].sampleList[j] = (0-A_start[i].sampleList[j])/ max;

            }
            B[i] = B_start[i] / max;
            X[i] = B_start[i] / max;
        }
    }

    private List<double> seidelMethod(List<double> B, List<List<double>> A, int Count)
    {
<<<<<<< Updated upstream
        List<double> X = new List<double>(B);

=======
        transformMatrix();
        
>>>>>>> Stashed changes

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
