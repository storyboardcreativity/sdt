﻿namespace VectorLib
{
    public class Matrix3D
    {
        private double[,] m_maxtrix;

        public double[,] Matrix
        {
            get { return m_maxtrix; }
            set { m_maxtrix = value; }
        }
        public Matrix3D()
        {
            Matrix = new double[4, 4];
        }

        public static Matrix3D IdentityMatrix()
        {
            Matrix3D _identity = new Matrix3D();
            for (int i = 0; i < 4; i++)
            {
                _identity.Matrix[i, i] = 1;
            }
            return _identity;
        }
        public void Normalize()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m_maxtrix[i, j] = m_maxtrix[i, j] / m_maxtrix[3, 3];
                }
            }
        }
        public static Matrix3D MatrixMultiply3D(Matrix3D a, Matrix3D b)
        {
            Matrix3D _result = new Matrix3D();
            double _value;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _value = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        _value=_value+(a.m_maxtrix[i,k]*b.m_maxtrix[k,j]);
                    }
                    _result.m_maxtrix[i, j] = _value;
                }
            }

            return _result;

        }

        

        public void Translate(double tx, double ty, double tz)
        {
            this.m_maxtrix[3, 0] = tx;
            this.m_maxtrix[3, 1] = ty;
            this.m_maxtrix[3, 2] = tz;
        }

        public void Translate(Vector3D v)
        {
            
            this.m_maxtrix[3, 0] = v.X;
            this.m_maxtrix[3, 1] = v.Y;
            this.m_maxtrix[3, 2] = v.Z;
            
        }
        public void Scale(Vector3D v)
        {
            
            this.m_maxtrix[1, 1] = v.X;
            this.m_maxtrix[2, 2] = v.Y;
            this.m_maxtrix[3, 3] = v.Z;
            
        }
        public Matrix3D Scale(double sx, double sy, double sz)
        {
            Matrix3D _result = Matrix3D.IdentityMatrix();
            _result.m_maxtrix[1, 1] = sx;
            _result.m_maxtrix[2, 2] = sy;
            _result.m_maxtrix[3, 3] = sz;
            return _result;
        }

        private double[] ApplyLeftMultiplication(double x, double y, double z, double w)
        {
            double[] _m = new double[4];
            for (int i = 0; i < 4; i++)
            {
                _m[i] = this.Matrix[i, 0] * x+this.Matrix[i, 1] * y+this.Matrix[i, 2] * z+ this.Matrix[i, 3] * w;
            }
            return _m;
        }
        private double[] ApplyRightMultiplication(double x, double y, double z, double w)
        {
            double[] _m = new double[4];
            for (int i = 0; i < 4; i++)
            {
                _m[i] = this.Matrix[0, i] * x+this.Matrix[1, i] * y+this.Matrix[2, i] * z+this.Matrix[3, i] * w;
            }
            return _m;
        }

        public double[] ApplyTransform(double x, double y, double z, double w)
        {
            double[] _res = new double[4];
            double[] _point = new double[] {x,y,z,w};
            double _value = 0;
            for (int i = 0; i < 4; i++)
            {
                _value = 0;
                for (int j = 0; j < 4; j++)
                {
                    _value = _value + _point[j] * m_maxtrix[j, i];
                }
                _res[i] = _value;
            }
            if (_value != 0.0)
            {
                _res[0] = _res[0] / _value;
                _res[1] = _res[1] / _value;
            }
            else
            {
                _res[3] = double.PositiveInfinity;
            }
            return _res;
        }
        public Point3D ApplyTransformToPt(double x, double y, double z, double w)
        {
            double[] _res = ApplyTransform(x, y, z, w);
            Point3D _pt = new Point3D(_res[0], _res[1], _res[2]);
            return _pt;
        }

        public static Point2D operator *(Matrix3D t, Point2D p)
        {
            double[] numArray = t.ApplyLeftMultiplication(p.X, p.Y, 0, 1);
            double num = (numArray[3] == 0 ? 1 : 1 / numArray[3]);
            return new Point2D(num * numArray[0], num * numArray[1]);
        }

        public static Point3D operator *(Matrix3D t, Point3D p)
        {
            double[] numArray = t.ApplyLeftMultiplication(p.X, p.Y, p.Z, 1);
            double num = (numArray[3] == 0 ? 1 : 1 / numArray[3]);
            return new Point3D(num * numArray[0], num * numArray[1],num*numArray[2]);
        }
        public static  Matrix3D operator +(Matrix3D a, Matrix3D b)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a.m_maxtrix[i, j] =a. m_maxtrix[i, j] + b.m_maxtrix[i, j];
                }
            }

            return a;
        }
      
    }
}
