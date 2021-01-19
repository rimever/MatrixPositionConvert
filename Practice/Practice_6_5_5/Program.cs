using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Practice_6_5_5
{
    /// <summary>
    /// 書籍「ゲーム開発のための数学・物理学入門」より
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                @"３次元の物体を45度ロール、90度ピッチ、-90度ヨーさせるための行列の一般式を一つの組み合わせ行列を使って作成しなさい。");
            var radian = 45d * Math.PI / 180d;
            var roll = Matrix.Build.DenseOfArray(new[,]
            {
                {Math.Cos(radian), -Math.Sin(radian), 0d, 0d},
                {Math.Sin(radian), Math.Cos(radian), 0d, 0d},
                {0d, 0d, 1d, 0d},
                {0d, 0d, 0d, 1d}
            });
            radian = 90d * Math.PI / 180d;
            var pitch = Matrix.Build.DenseOfArray(new[,]
            {
                {1d, 0d, 0d, 0d},
                {0d, Math.Cos(radian), -Math.Sin(radian), 0d},
                {0d, Math.Sin(radian), Math.Cos(radian), 0d},
                {0d, 0d, 0d, 1d}
            });
            radian = -90d * Math.PI / 180d;
            var yaw = Matrix.Build.DenseOfArray(new[,]
            {
                {Math.Cos(radian), 0d, Math.Sin(radian), 0d},
                {0d, 1d, 0d, 0d},
                {-Math.Sin(radian), 0d, Math.Cos(radian), 0d},
                {0d, 0d, 0d, 1d}
            });
            // 発生する順に右から並べる
            var mergeMatrix = yaw * pitch * roll;
            Console.WriteLine(mergeMatrix);
            Console.WriteLine("また、その式を使って頂点がD(200,0,-30),E(0,50,-150), F(40,20,-100)の三角形を回転させなさい。");
            Console.WriteLine(mergeMatrix * Matrix.Build.DenseOfArray(new[,]
            {
                {200d},
                {0d},
                {-30d},
                {1d}
            }));
            Console.WriteLine(mergeMatrix * Matrix.Build.DenseOfArray(new[,]
            {
                {0d},
                {50d},
                {-150d},
                {1d}
            }));
            Console.WriteLine(mergeMatrix * Matrix.Build.DenseOfArray(new[,]
            {
                {40d},
                {20d},
                {-100d},
                {1d}
            }));
            Console.WriteLine("DirectX（行ベクトル）で使える形にしなさい");
            var convertDirectX = mergeMatrix.Inverse(); 
            Console.WriteLine(convertDirectX);
            Console.WriteLine(Matrix.Build.DenseOfArray(new[,]
            {
                {200d,0d,-30d,1d}
            }) * convertDirectX);
            Console.WriteLine(Matrix.Build.DenseOfArray(new[,]
            {
                {0d,50d,-150d,1d}
            }) * convertDirectX);
            Console.WriteLine(Matrix.Build.DenseOfArray(new[,]
            {
                {40d,20d,-100d,1d}
            }) * convertDirectX);
        }
    }
}