using System;

namespace VectorLib
{
    public class Vector2D:Point2D
    {
        #region Properties

        /// <summary>
        /// Returns Angle in Radians -pi to +pi range
        /// </summary>
        public double AngleR
        {
            get { return Math.Atan2(base.Y, base.X); }
        }
        /// <summary>
        /// Returns Angle in Degrees -180 to +180 range
        /// </summary>
        
        public double AngleD
        {
            get { return AngleR * 180 / Math.PI; }
        }

        public double Length
        {
            get
            {
                return Utility.Round(Math.Sqrt(X * X + Y * Y));
            }
            set
            {
                double val = Math.Sqrt(X * X + Y * Y);
                X = X * value / val;
                Y = Y* value / val;
            }
        }
        public static Vector2D XAxis
        {
            get
            {
                return new Vector2D(1,0);
            }
        }

         public static Vector2D YAxis
        {
            get
            {
                return new Vector2D(0,1);
            }
        }

        public bool IsUnitVector
        {
            get
            {
                return Math.Abs(this.Length-1)<=Utility.Domain;
            }
        }
        public bool IsZero
        {
            get
            {
                return this.Length<=Utility.Domain;
            }

        }

        #endregion

        #region Constructor
        public Vector2D()
        {
        }
        public Vector2D(double x, double y)
            : base(x, y)
        {
        }

        public Vector2D(Point2D a, Point2D b)
        {
            base.X = a.X - b.X;
            base.Y = a.Y - b.Y;
        }
        public Vector2D(double[] coord)
            : base(coord)
        {
        }
        public Vector2D(Vector2D otherVector):base(otherVector)
        {
         
        }

        #endregion

        #region Methods
        /// <summary>
        /// Returns the angle between a and b vector in radians
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double AngleBetweenR(Vector2D a, Vector2D b)
        {
            double val = (a * b) / (a.Length * b.Length);
            return Math.Acos(val);
        }
        public static double AngleBetweenD(Vector2D a, Vector2D b)
        {
            return AngleBetweenR(a, b) * 180 / Math.PI;
        }
        public static double operator *(Vector2D a, Vector2D b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public static Vector2D operator *(Vector2D a, double factor)
        {
            return new Vector2D(a.X * factor, a.Y * factor);
        }
        public static Vector2D operator *(double factor,Vector2D a)
        {
            return new Vector2D(a.X * factor, a.Y * factor);
        }
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }

        public static double DotProduct(Vector2D a, Vector2D b)
        {
            return a * b;
        }

        public static double DotProduct(Vector2D a, Point2D b)
        {
            return a.X * b.X+a.Y*b.Y;
        }
        public static double DotProduct(Point2D b, Vector2D a)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public Vector2D GetNormal()
        {
            double val = this.Length;
            return new Vector2D(X / val,Y/val);
        }
        public void NormalizeVector()
        {
            double val= this.Length;
            X = X / val;
            Y = Y / val;
        }
        private static double PerpendicularDotProduct(Vector2D a, Vector2D b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static Vector2D Subtract(Point2D a, Point2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }
        public static double SignedAngleBetweenR(Vector2D a, Vector2D b)
        {
            return Math.Atan2(Vector2D.PerpendicularDotProduct(a, b), Vector2D.DotProduct(a, b));
        }
        public static double SignedAngleBetweenD(Vector2D a, Vector2D b)
        {
            return SignedAngleBetweenR(a, b) * 180 / Math.PI;
        }
        public static double AngleBetweenIn360(Vector2D a, Vector2D b)
        {
            double val = SignedAngleBetweenD(a, b);
            if (val < 0)
                val = val + 360;
            return val;
        }

        public static double AngleBetweenIn2PI(Vector2D a, Vector2D b)
        {
            double val = SignedAngleBetweenR(a, b);
            if (val < 0)
                val = val + 2*Math.PI;
            return val;
        }

        public static Vector2D Add(Point2D a, Point2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public override string ToString()
        {
            return X.ToString() + "," + Y.ToString() + "," + Length.ToString() + "," + AngleD.ToString();
        }
        public static bool IsParallel(Vector2D a, Vector2D b)
        {
            return Math.Abs(1 - a * b) < Utility.Domain;
        }
        #endregion
    }
}
