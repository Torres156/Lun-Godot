using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Shared.Models
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x;
        public float y;

        public static readonly Vector2 Zero = new Vector2(0);
        public static readonly Vector2 One = new Vector2(1f);


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="value"></param>
        public Vector2(float value) : this(value, value)
        { }

        /// <summary>
        /// Verifica se o vetor é igual
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vector2 other)
            => other.x == x && other.y == y;

        /// <summary>
        /// Distância entre 2 pontos
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Distance(Vector2 other)
            => (float)Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));


        public override int GetHashCode()
            => x.GetHashCode() + y.GetHashCode();

        public override bool Equals(object obj)
            => (obj is Vector2) && Equals((Vector2)obj);

        public Vector2 Floor()
            => new Vector2((float)Math.Floor(x), (float)Math.Floor(y));

        public Vector2 Round()
            => new Vector2((float)Math.Round(x, 2), (float)Math.Round(y, 2));

        public Vector2 Ceiling()
            => new Vector2((float)Math.Ceiling(x), (float)Math.Ceiling(y));

        public Vector2 ToInt()
            => new Vector2((int)x, (int)y);

        public static Vector2 Max(Vector2 v1, Vector2 v2)
            => new Vector2((float)Math.Max(v1.x, v2.x), (float)Math.Max(v1.y, v2.y));

        public static Vector2 Min(Vector2 v1, Vector2 v2)
            => new Vector2((float)Math.Min(v1.x, v2.x), (float)Math.Min(v1.y, v2.y));

        #region Operators
        public static Vector2 operator -(Vector2 value, Vector2 other)
            => new Vector2(value.x - other.x, value.y - other.y);

        public static Vector2 operator -(Vector2 value, float other)
            => new Vector2(value.x - other, value.y - other);

        public static Vector2 operator +(Vector2 value, Vector2 other)
            => new Vector2(value.x + other.x, value.y + other.y);

        public static Vector2 operator +(Vector2 value, float other)
            => new Vector2(value.x + other, value.y + other);

        public static Vector2 operator *(Vector2 value, Vector2 other)
            => new Vector2(value.x * other.x, value.y * other.y);

        public static Vector2 operator *(Vector2 value, float other)
            => new Vector2(value.x * other, value.y * other);

        public static Vector2 operator /(Vector2 value, Vector2 other)
            => new Vector2(value.x / other.x, value.y / other.y);

        public static Vector2 operator /(Vector2 value, float other)
            => new Vector2(value.x / other, value.y / other);

        public static bool operator ==(Vector2 value, Vector2 other)
            => value.x == other.x && value.y == other.y;

        public static bool operator !=(Vector2 value, Vector2 other)
            => value.x != other.x || value.y != other.y;
        
        #endregion

    }
}
