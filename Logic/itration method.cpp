// itration method.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

struct Matrix3x3
{
    float matrix[3][3] = {};
};

struct Matrix3x1
{
    float matrix[3] = {};
};

Matrix3x1 Multi(Matrix3x3 matrix1, Matrix3x1 matrix2) {
    Matrix3x1 answer;

    for (size_t i = 0; i < 3; i++)
    {
        answer.matrix[i] = matrix1.matrix[i][0] * matrix2.matrix[0] + matrix1.matrix[i][1] * matrix2.matrix[1] + matrix1.matrix[i][2] * matrix2.matrix[2] ;

    }
    return answer;
}

Matrix3x1 Plus( Matrix3x1 matrix1, Matrix3x1 matrix2) {
    Matrix3x1 answer;
    for (size_t i = 0; i < 3; i++)
    {
        answer.matrix[i] = matrix1.matrix[i]  + matrix2.matrix[i];

    }

    return answer;
}

void Show(Matrix3x1 matrix) {
    std::cout << "---------------------" << std::endl;
    for (size_t i = 0; i < 3; i++)
    {

        std::cout << matrix.matrix[i] << std::endl;

    }
    std::cout << "---------------------" << std::endl;
}
int main()
{
    Matrix3x1 B = { 1.2,1.3,1.4 };
    Matrix3x1 X = { 1.2,1.3,1.4 };
    Matrix3x3 A = {
    0  , -.1, -0.2,
    -0.2, 0  , -0.1,
    -0.2, -0.2, 0  };
    for (size_t i = 0; i < 100000; i++)
    {
        X = Plus(B, Multi(A, X));
    }
    
    Show(X);
    
    return 0;
}
