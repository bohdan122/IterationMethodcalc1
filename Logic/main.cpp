

#include <iostream>
#include <iomanip>
#include <vector>
typedef std::vector<double> d1Matrix;
typedef std::vector <d1Matrix> d2Matrix;

d1Matrix Multi(d2Matrix matrix1, d1Matrix matrix2) {
    d1Matrix answer;

    for (size_t i = 0; i < 3; i++)
    {
        answer.push_back(matrix1.at(i).at(0) * matrix2.at(0) + matrix1.at(i).at(1) * matrix2.at(i) + matrix1.at(i).at(2) * matrix2.at(2));

    }
    return answer;
}

d1Matrix Plus(d1Matrix matrix1, d1Matrix matrix2) {
    d1Matrix answer;
    for (size_t i = 0; i < 3; i++)
    {
        answer.push_back(matrix1.at(i) + matrix2.at(i));

    }

    return answer;
}

void Show(d1Matrix matrix) {
    std::cout << "---------------------" << std::endl;
    for (size_t i = 0; i < 3; i++)
    {

        std::cout <<std::setprecision(308)<< matrix.at(i) << std::endl;

    }
    std::cout << "---------------------" << std::endl;
}

d1Matrix iterationMethod(d1Matrix B, d2Matrix A,int count_of_iteratin) {
    d1Matrix X = B;
    for (size_t i = 0; i < count_of_iteratin; i++)
    {
        X = Plus(B, Multi(A, X));
    }
    return X;
}


d1Matrix SeidelMethod(d1Matrix B, d2Matrix A, int count_of_iteratin) {
    d1Matrix X = B;
    for (size_t i = 0; i < count_of_iteratin; i++)
    {
        for (size_t i = 0; i < B.size(); i++)
        {
            X[i] = B[i] + (A.at(i).at(0) * X.at(0) + A.at(i).at(1) * X.at(i) + A.at(i).at(2) * X.at(2));
        }
        
    }
    return X;
}

int main()
{
    d1Matrix B = { 1.2,1.3,1.4 };
    d1Matrix X = { 1.2,1.3,1.4 };
    d2Matrix A = {
        {  0  , -0.1, -0.1 },
        { -0.2,  0  , -0.1 },
        { -0.2, -0.2,  0   }
                            };
   
    Show(SeidelMethod(B,A,4));

    Show(iterationMethod(B, A, 4));
    
    return 0;
}
