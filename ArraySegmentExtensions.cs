using System;
using System.Collections.Generic;

namespace IS4.Tools
{
    internal static class ArraySegmentExtensions
    {
        public static ArraySegment<T> Slice<T>(this ArraySegment<T> segment, int start, int length)
        {
            if(start < 0) throw new ArgumentOutOfRangeException(nameof(start));
            if(start + length > segment.Count) throw new ArgumentOutOfRangeException(nameof(length));
            return new ArraySegment<T>(segment.Array, segment.Offset + start, length);
        }

        public static ArraySegment<T> Slice<T>(this ArraySegment<T> segment, int start)
        {
            if(start < 0 || start > segment.Count) throw new ArgumentOutOfRangeException(nameof(start));
            return new ArraySegment<T>(segment.Array, segment.Offset + start, segment.Count - start);
        }

        public static ArraySegment<T> Slice<T>(this T[] array, int start, int length)
        {
            if(start < 0) throw new ArgumentOutOfRangeException(nameof(start));
            if(start + length > array.Length) throw new ArgumentOutOfRangeException(nameof(length));
            return new ArraySegment<T>(array, start, length);
        }

        public static void CopyTo<T>(this ArraySegment<T> segment, T[] array, int index = 0)
        {
            Array.Copy(segment.Array, segment.Offset, array, index, segment.Count);
        }

        public static T At<T>(this ArraySegment<T> segment, int index)
        {
            return AtList<ArraySegment<T>, T>(segment, index);
        }

        private static T AtList<TList, T>(TList list, int index) where TList : struct, IReadOnlyList<T>
        {
            return list[index];
        }
    }
}
