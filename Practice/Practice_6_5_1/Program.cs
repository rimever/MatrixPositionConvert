using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Practice_6_5_1
{
    /// <summary>
    /// 書籍「ゲーム開発者のための物理・数学入門」より
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                @"２次元の物体を一度のステップでその中心点周りに-90度回転させるための組み合わせ行列を作りなさい。
ただし、物体の中心点の座標は(10,50)とします。");
            var move = Matrix.Build.DenseOfArray(new[,]
            {
                {1d, 0d, 10d},
                {0d, 1d, 50d},
                {0d, 0d, 1d}
            });
            var radian = -90d * Math.PI / 180d;
            var rotate =Matrix.Build.DenseOfArray(new[,]
            {
                {Math.Cos(radian), -Math.Sin(radian), 0d},
                {Math.Sin(radian), Math.Cos(radian), 0d},
                {0d, 0d, 1d}
            });
            var move2 = Matrix.Build.DenseOfArray(new[,]
            {
                {1d, 0d, -10d},
                {0d, 1d, -50d},
                {0d, 0d, 1d}
            });
            var mergeMatrix = move * rotate * move2;
            Console.WriteLine(mergeMatrix);
            Console.WriteLine(@"作成した行列を使って、頂点がA(-10,50),B(90,0),C(-50,100)の三角形を回転させなさい");
            var a = Matrix.Build.DenseOfArray(new[,]
            {
                {-10d},
                {50d},
                {1d}
            });
            Console.WriteLine(mergeMatrix * a);
            var b = Matrix.Build.DenseOfArray(new[,]
            {
                {90d},
                {0d},
                {1d}
            });
            Console.WriteLine(mergeMatrix * b);
            var c = Matrix.Build.DenseOfArray(new[,]
            {
                {-50d},
                {100d},
                {1d}
            });
            Console.WriteLine(mergeMatrix * c);
        }
    }
}