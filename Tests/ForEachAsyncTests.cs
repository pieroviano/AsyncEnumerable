using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Tests;

public partial class ForEachAsyncTests
{
    [Test]
    public void SimpleSyncForEach()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield =>
            {
                for (int i = 0; i < 5; i++)
                    await yield.ReturnAsync(i);
            });

#pragma warning disable CS0612 // Type or member is obsolete
        int counter = 0;
        foreach (var number in enumerable.ToEnumerable())
        {
            Assert.AreEqual(counter, number);
            counter++;
        }
#pragma warning restore CS0612 // Type or member is obsolete
    }

}