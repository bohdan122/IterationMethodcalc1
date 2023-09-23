using System;
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
    [SerializeField] private List<double> B = new List<double>();
    [SerializeField] private List<double> B_start = new List<double>();
    public List<serializableClass> A = new List<serializableClass>();
    public List<serializableClass> A_start = new List<serializableClass>();

    [SerializeField] public List<double> X = new List<double>();

    private double mistake;

    public int whatmethodoweusetellmepls = 0;
    
    private int itertion_count;


    [SerializeField] GameObject outManager;
    public void DoShit(int num)
    {
        whatmethodoweusetellmepls = num;
        CalculateThishShit();
    }

    public void next_previous(int num) {
     if(!(itertion_count == 0 && num == -1))
        {
            itertion_count += num;
        }
     CalculateThishShit();
    }

    public void Button(int num)
    {
        itertion_count = num;
        CalculateThishShit();
    }

    public void CalculateThishShit()
    {
        if (whatmethodoweusetellmepls == 0)
        {
            itrerationMethod(itertion_count);
        }
        else
        {
            seidelMethod(itertion_count);
        }

        for (int i = 0; i < X.Count; i++)
        {
            Debug.Log(X[i].ToString());
        }
        outManager.GetComponent<outputManageer>().outputNumbers(X);
        outManager.GetComponent<outputManageer>().outputIteration(itertion_count);
    }





    private void Start()
    {

        itertion_count = 0;


        A.Add(new serializableClass());
        A.Add(new serializableClass());
        A.Add(new serializableClass());

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
        {
            B.Add(default(double));

        }
        for (int j = 0; j < 3; j++)
        {
            B_start.Add(default(double));

        }
        for (int j = 0; j < 3; j++)
        {
            X.Add(default(double));

        }

    }

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
    private void itrerationMethod( int Count)
    {
        transformMatrix();


        for (int i = 0; i < Count; i++)
        {
            X = Plus(B, Multi(A, X));
        }


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

    private void seidelMethod(int Count)
    {
        transformMatrix();
     
        for (int h = 0; h < Count; h++)
        {
            for (int i = 0; i < X.Count; i++)
            {
                X[i] = B[i] + (A[i].sampleList[0] * X[0] + A[i].sampleList[1] * X[1] + A[i].sampleList[2] * X[2]);
            }

        }

    }
}
