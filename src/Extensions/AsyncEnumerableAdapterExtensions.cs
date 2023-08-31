using System.Collections.Generic;
using System.Collections.Internals;
using System.ComponentModel;

namespace System.Collections;

/// <summary>
/// Extension methods for <see cref="IAsyncEnumerable{T}"/> for backward compatibility with version 1 of this libraray.
/// Not recommended to use.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class AsyncEnumerableAdapterExtensions
{
#if !NETSTANDARD2_1 && !NETSTANDARD2_0 && !NET461
    /// <summary>
    /// Converts <see cref="IAsyncEnumerable"/> to <see cref="IEnumerable"/>.
    /// This method is marked as [Obsolete] to discourage you from doing such conversion,
    /// which defeats the whole purpose of having a non-blocking async enumeration,
    /// and what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerable ToEnumerable(this IAsyncEnumerable asyncEnumerable)
    {
        if (asyncEnumerable == null)
            throw new ArgumentNullException(nameof(asyncEnumerable));
        if (asyncEnumerable is IEnumerable enumerable)
            return enumerable;
        return new EnumerableAdapter(asyncEnumerable);
    }

    /// <summary>
    /// Converts <see cref="IAsyncEnumerator"/> to <see cref="IEnumerator"/>.
    /// This method is marked as [Obsolete] to discourage you from doing such conversion,
    /// which defeats the whole purpose of having a non-blocking async enumeration,
    /// and what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerator ToEnumerator(this IAsyncEnumerator asyncEnumerator)
    {
        if (asyncEnumerator == null)
            throw new ArgumentNullException(nameof(asyncEnumerator));
        if (asyncEnumerator is IEnumerator enumerator)
            return enumerator;
        return new EnumeratorAdapter(asyncEnumerator);
    }

    /// <summary>
    /// Creates an enumerator that iterates through a collection synchronously.
    /// This method is marked as [Obsolete] to discourage you from using this synchronous version of
    /// the method instead of <see cref="IAsyncEnumerable.GetAsyncEnumerator"/>,
    /// what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerator GetEnumerator(this IAsyncEnumerable asyncEnumerable)
    {
        if (asyncEnumerable == null)
            throw new ArgumentNullException(nameof(asyncEnumerable));
        return asyncEnumerable.GetAsyncEnumerator().ToEnumerator();
    }

    /// <summary>
    /// Advances the enumerator to the next element of the collection synchronously.
    /// This method is marked as [Obsolete] to discourage you from using this synchronous version of
    /// the method instead of <see cref="IAsyncEnumerator.MoveNextAsync()"/>,
    /// what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static bool MoveNext(this IAsyncEnumerator asyncEnumerator)
    {
        if (asyncEnumerator == null)
            throw new ArgumentNullException(nameof(asyncEnumerator));
        return asyncEnumerator.MoveNextAsync().GetAwaiter().GetResult();
    }
#endif

    /// <summary>
    /// Converts <see cref="IAsyncEnumerable{T}"/> to <see cref="IEnumerable{T}"/>.
    /// This method is marked as [Obsolete] to discourage you from doing such conversion,
    /// which defeats the whole purpose of having a non-blocking async enumeration,
    /// and what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerable<T> ToEnumerable<T>(this IAsyncEnumerable<T> asyncEnumerable)
    {
        if (asyncEnumerable == null)
            throw new ArgumentNullException(nameof(asyncEnumerable));
        if (asyncEnumerable is IEnumerable<T> enumerable)
            return enumerable;
        return new EnumerableAdapter<T>(asyncEnumerable);
    }

    /// <summary>
    /// Converts <see cref="IAsyncEnumerator{T}"/> to <see cref="IEnumerator{T}"/>.
    /// This method is marked as [Obsolete] to discourage you from doing such conversion,
    /// which defeats the whole purpose of having a non-blocking async enumeration,
    /// and what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerator<T> ToEnumerator<T>(this IAsyncEnumerator<T> asyncEnumerator)
    {
        if (asyncEnumerator == null)
            throw new ArgumentNullException(nameof(asyncEnumerator));
        if (asyncEnumerator is IEnumerator<T> enumerator)
            return enumerator;
        return new EnumeratorAdapter<T>(asyncEnumerator);
    }

    /// <summary>
    /// Creates an enumerator that iterates through a collection synchronously.
    /// This method is marked as [Obsolete] to discourage you from using this synchronous version of
    /// the method instead of <see cref="IAsyncEnumerable{T}.GetAsyncEnumerator"/>,
    /// what might lead to dead-locks in ASP.NET or WPF applications.
    /// </summary>
    [Obsolete]
    public static IEnumerator<T> GetEnumerator<T>(this IAsyncEnumerable<T> asyncEnumerable)
    {
        if (asyncEnumerable == null)
            throw new ArgumentNullException(nameof(asyncEnumerable));
        return asyncEnumerable.GetAsyncEnumerator().ToEnumerator();
    }
}