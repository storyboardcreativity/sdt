using System;

namespace VectorLib
{
    public class Point3D:Point2D
    {
        #region Member Variable
        private double m_z;
        private double m_backZ;
        #endregion

        #region Properties
        public double Z
        {
            get { return m_z; }
            set
            {
                m_backZ = value;
                m_z = Utility.Round(value);
            }
        }

        public double MaxCoodinate
        {
            get { return Math.Max(base.MaxCoordinate, Math.Abs(Z)); }

        }

        public static Point3D Origin
        {
            get { return new Point3D(0, 0, 0); }
        }
      
        #endregion

        #region Constrcutor
        public Point3D()
        {
        }
        public Point3D(double x, double y, double z):base(x,y)
        {
            Z = z;
        }
        public Point3D(Point3D otherPoint)
        {
            base.X = otherPoint.X;
            base.Y = otherPoint.Y;
            Z = otherPoint.Z;
        }

        public Point3D(double[] coord):base(coord)
        {
            Z = coord[2];
        }
        #endregion

        #region Methods
        public static double Distance(Point3D a, Point3D b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            double z = a.Z - b.Z;
            return Math.Sqrt((x * x) + (y * y) + (z * z));

        }

        internal double BackZ
        {
            get { return m_backZ; }
        }
        public double DistanceTo(Point3D b)
        {
            return Point3D.Distance(this, b);
        }

        public static  bool IsEqual(Point3D a, Point3D b)
        {
            return (Point3D.Distance(a, b) <= Utility.Domain);
        }

        public double[] ToArray()
        {
            return new double[] { this.X, this.Y, this.Z };
        }

            
        #endregion  

        #region Override Methods
        public override object Clone()
        {
            return new Point3D(this.BackX, this.BackY, m_backZ); 
        }
        public override string ToString()
        {
            return (X.ToString() + "," + Y.ToString() + "," + Z.ToString());
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            else
                return (Utility.IsEqual(this.X, ((Point3D)obj).X) && 
                    Utility.IsEqual(this.Y, ((Point3D)obj).Y) && 
                    Utility.IsEqual(this.Z,((Point3D)obj).Z));
        }
        public override int GetHashCode()
        {
            double z = this.Z;
            return base.GetHashCode() * 397 ^ z.GetHashCode();
        }
        #endregion

        #region Operator Overloading

        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.BackX + b.BackX, a.BackY + b.BackY, a.m_backZ + b.m_backZ);
        }
        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.BackX - b.BackX, a.BackY - b.BackY, a.m_backZ - b.m_backZ);
        }
        public static Point3D operator /(Point3D a, double b)
        {
            return new Point3D(a.BackX/b,a.BackY/b,a.BackZ/b);
        }
        public static Point3D operator *(Point3D a, double b)
        {
            return new Point3D(a.BackX * b, a.BackY*b, a.BackZ * b);
        }
        public static Point3D operator *(double b,Point3D a)
        {
            return new Point3D(a.BackX / b, a.BackY / b, a.BackZ / b);
        }
        public static bool operator ==(Point3D a, Point3D b)
        {
            return Point3D.Equals(a, b);
        }
        public static bool operator !=(Point3D a, Point3D b)
        {
            return !Point3D.Equals(a, b);
        }

        #endregion
    }
}
