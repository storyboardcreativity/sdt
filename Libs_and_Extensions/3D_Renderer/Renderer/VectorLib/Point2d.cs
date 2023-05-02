using System;

namespace VectorLib
{
    public class Point2D:ICloneable
    {

        #region Members
        private double m_x;
        private double m_backX;
        private double m_y;
        private double m_backY;
        #endregion

        #region Properties

        public double X
        {
            get { return m_x; }
            set {
                m_backX = value;
                m_x = Utility.Round(value);
                }
        }
        public double Y
        {
            get { return m_y; }
            set {
                m_backY = value;
                m_y = Utility.Round(value);
                }
        }

        public static Point2D Origin
        {
            get { return new Point2D(0, 0); }
        }
        public double MaxCoordinate
        {
            get { return Math.Max(Math.Abs(X), Math.Abs(Y)); }
        }
        internal double BackX
        {
            get { return m_backX; }
        }
        internal double BackY
        {
            get { return m_backY; }
        }
        #endregion

        #region Methods

        public double DistanceTo(Point2D b)
        {
            return Point2D.Distance(this, b);
        }

        public static double Distance(Point2D a, Point2D b)
        {

            return Utility.Round(Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2)));
        }


        public static bool IsEqual(Point2D a, Point2D b)
        {
            return (Point2D.Distance(a, b) <= Utility.Domain);
        }

        public Point2D PointClone()
        {
            return new Point2D(this.m_backX, this.m_backY);
        }
        public virtual object Clone()
        {
            return PointClone();
        }
        public double[] ToArray()
        {
            return new double[] { this.X, this.Y };
        }
        
        #endregion 

        #region Override Methods
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            else
                return Utility.IsEqual(this.X, ((Point2D)obj).X) && Utility.IsEqual(this.Y, ((Point2D)obj).Y);
        }
        public override string ToString()
        {
            return (X.ToString() + "," + Y.ToString());
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() * 397 ^ Y.GetHashCode();
        }
        
        #endregion

        #region Constructor
        public Point2D()
        {
        }
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point2D(double[] args)
        {
            try
            {
                if (args.Length == 2)
                {
                    X = args[0];
                    Y = args[1];
                }
                else
                {
                    throw new Exception("Invalid array length");
                }
            }
            catch (Exception e)
            {
                //todo
            }
        }

        public Point2D(Point2D otherPoint)
        {
            X = otherPoint.X;
            Y = otherPoint.Y;
        }
        #endregion

        #region Operator OverLoading
        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.m_backX + b.m_backX, a.m_backY + b.m_backY);
        }

        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.m_backX - b.m_backX, a.m_backY - b.m_backY);
        }

        public static Point2D operator /(Point2D a, double factor)
        {
            return new Point2D(a.m_backX /factor, a.m_backY /factor);
        }

        public static Point2D operator *(Point2D a, double factor)
        {
            return new Point2D(a.m_backX *factor, a.m_backY* factor);
        }
        public static Point2D operator *(double factor, Point2D a)
        {
            return new Point2D(a.m_backX * factor, a.m_backY * factor);
        }

        public static bool operator ==(Point2D a, Point2D b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point2D a, Point2D b)
        {
            return !a.Equals(b);
        }
        #endregion


    }

    
}
