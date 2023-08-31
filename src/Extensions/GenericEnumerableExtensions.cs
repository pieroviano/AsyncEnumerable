using System.Collections.Generic;
using System.Collections.Internals;
using System.ComponentModel;
using System.Linq;

namespace System.Collections;

/// <summary>
/// Converts generic IEnumerable to IAsyncEnumerable
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class GenericEnumerableExtensions
{
    /// <summary>
    /// Creates <see cref="IAsyncEnumerable{T}"/> adapter for <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="enumerable">The instance of <see cref="IEnumerable{T}"/> to convert</param>
    /// <param name="runSynchronously">If True the enumeration will be performed on the same thread, otherwise the MoveNext will be executed on a separate thread with Task.Run method</param>
    /// <returns>Returns an instance of <see cref="IAsyncEnumerable{T}"/> implementation</returns>
    public static IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> enumerable, bool runSynchronously = true)
    {
        if (enumerable == null)
            throw new ArgumentNullException(nameof(enumerable));
        if (ReferenceEquals(enumerable, Enumerable.Empty<T>()))
            return AsyncEnumerable<T>.Empty;
        return enumerable as IAsyncEnumerable<T> ?? new AsyncEnumerableWrapper<T>(enumerable, runSynchronously);
    }

    /// <summary>
    /// Creates <see cref="IAsyncEnumerator{T}"/> adapter for the enumerator of <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="enumerable">The instance of <see cref="IEnumerable{T}"/> to convert</param>
    /// <param name="runSynchronously">If True the enumeration will be performed on the same thread, otherwise the MoveNext will be executed on a separate thread with Task.Run method</param>
    /// <returns>Returns an instance of <see cref="IAsyncEnumerable{T}"/> implementation</returns>
    public static IAsyncEnumerator<T> GetAsyncEnumerator<T>(this IEnumerable<T> enumerable, bool runSynchronously = true)
    {
        if (enumerable == null)
            throw new ArgumentNullException(nameof(enumerable));

        if (enumerable is IAsyncEnumerable<T> asyncEnumerable)
            return asyncEnumerable.GetAsyncEnumerator();

        var enumerator = enumerable.GetEnumerator();
        return new AsyncEnumeratorWrapper<T>(enumerator, runSynchronously);
    }

    /// <summary>
    /// Creates <see cref="IAsyncEnumerator{T}"/> adapter for <see cref="IEnumerator{T}"/>
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    /// <param name="enumerator">The instance of <see cref="IEnumerator{T}"/> to convert</param>
    /// <param name="runSynchronously">If True the enumeration will be performed on the same thread, otherwise the MoveNext will be executed on a separate thread with Task.Run method</param>
    /// <returns>Returns an instance of <see cref="IAsyncEnumerator{T}"/> implementation</returns>
    public static IAsyncEnumerator<T> ToAsyncEnumerator<T>(this IEnumerator<T> enumerator, bool runSynchronously = true)
    {
        if (enumerator == null)
            throw new ArgumentNullException(nameof(enumerator));
        return enumerator as IAsyncEnumerator<T> ?? new AsyncEnumeratorWrapper<T>(enumerator, runSynchronously);
    }
}