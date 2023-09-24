using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////
    ///////////////////////   Variables    ///////////////////////////////////
    //////////////////////////////////////////////////////////////////////////

    [System.Serializable]
    public class ListForInspector ///act like a list, but shown in an inspector
    {
        public List<double> list = new List<double>();
    }
   
    [SerializeField] private List<double> beta = new List<double>();
    
    [SerializeField] private List<double> B = new List<double>();
    
    public List<ListForInspector> alpha = new List<ListForInspector>();
    
    public List<ListForInspector> A = new List<ListForInspector>();

    [SerializeField] public List<double> X = new List<double>();

    [SerializeField] private double mistake;

    public int method = 0;
    
    private int itertion_count = 0;


    [SerializeField] GameObject outManager;

    //////////////////////////////////////////////////////////////////////////
    ///////////////////////    Start()     ///////////////////////////////////
    //////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            alpha.Add(new ListForInspector());

            A.Add(new ListForInspector());

            beta.Add(default(double));

            B.Add(default(double));

            X.Add(default(double));
            for (int j = 0; j < 3; j++)
            {
                alpha[i].list.Add(0);
                A[i].list.Add(0);
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////
    ///////////////////////   Procesing Inputs   /////////////////////////////
    //////////////////////////////////////////////////////////////////////////
    public void CangeMethod(int num)
    {
        method = num;

        ProcesCalculations();
    }

    public void ChangeIteration(int num)
    {
        if (!(itertion_count == 0 && num == -1))
        {
            itertion_count += num;
        }

        ProcesCalculations();
    }

    public void Getnumber(int x, int y, double number)
    {
        if (x == 4)
        {
            mistake = number;

        }
        else if (x == 3)
        {
            B[y] = number;
        }
        else 
        {
            A[x].list[y] = number;
        }
    }

    public void Button(int num)
    {
        itertion_count = num;

        ProcesCalculations();
    }

    //////////////////////////////////////////////////////////////////////////
    /////////////////////////      Output     ////////////////////////////////
    //////////////////////////////////////////////////////////////////////////

    public void ProcesCalculations()
    {
        List<double> answer;

        if (method == 0)
        {
            answer = ItrerationMethod(itertion_count).ToList();
        }
        else
        {
            answer = SeidelMethod(itertion_count).ToList();
        }

        for (int i = 0; i < X.Count; i++)
        {
            Debug.Log(answer[i].ToString());
        }

        outManager.GetComponent<outputManageer>().outputNumbers(answer);
        outManager.GetComponent<outputManageer>().outputIteration(itertion_count);
    }

    //////////////////////////////////////////////////////////////////////////
    //////////////////////      Calculation      /////////////////////////////
    //////////////////////////////////////////////////////////////////////////

    void transformMatrix()
    {
        for (int i = 0; i < 3; i++)
        {
            double max = A[i].list[i];
            for (int j = 0; j < 3; j++)
            {
                if (i == j)
                {
                    alpha[i].list[j] = 0;
                    continue;
                }

                alpha[i].list[j] = (0 - A[i].list[j]) / max;

            }
            beta[i] = B[i] / max;
            X[i] = B[i] / max;
        }
    }

    ////////////////////// Iteration Method /////////////////////////
    private List<double> Multi(List<ListForInspector> matrix1, List<double> matrix2)
    {
        List<double> result = new List<double>();

        for (int i = 0; i < matrix2.Count; i++)
        {
            result.Add(matrix1[i].list[0] * matrix2[0] + matrix1[i].list[1] * matrix2[1] + matrix1[i].list[2] * matrix2[2]);
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

    private List<double> ItrerationMethod( int Count)
    {
        transformMatrix();

        for (int i = 0; i < Count; i++)
        {
            X = Plus(beta, Multi(alpha, X));
        }

        return X;
    }

    ////////////////////// Seidel Method /////////////////////////
    private List<double> SeidelMethod(int Count)
    {
        
        transformMatrix();
     
        for (int h = 0; h < Count; h++)
        {
            for (int i = 0; i < X.Count; i++)
            {
                X[i] = beta[i] + (alpha[i].list[0] * X[0] + alpha[i].list[1] * X[1] + alpha[i].list[2] * X[2]);
            }

        }

        return X;
    }
}
