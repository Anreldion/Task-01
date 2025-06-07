using ClassLibrary.Utilities;
using NUnit.Framework;
using System;

namespace Tests.Utilities;

[TestFixture]
[TestOf(typeof(Guard))]
public class GuardTest
{

    [Test]
    public void NotNull_ThrowsException()
    {
        string value = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            Guard.NotNull(value, nameof(value));
        });
    }

    [Test]
    public void NotNull_DoesNotThrowException()
    {
        const string value = "notNull";
        Assert.DoesNotThrow(() =>
        {
            Guard.NotNull(value, nameof(value));
        });
    }
    [Test]
    public void NotEmpty_ThrowsException()
    {
        var value = string.Empty;
        Assert.Throws<InvalidOperationException>(() =>
        {
            Guard.NotEmpty(value, nameof(value));
        });
    }

    [Test]
    public void NotEmpty_DoesNotThrowException()
    {
        const string value = "notNull";
        Assert.DoesNotThrow(() =>
        {
            Guard.NotEmpty(value, nameof(value));
        });
    }
    [Test]
    public void AgainstNegative_ThrowsException()
    {
        const int value = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Guard.AgainstNegative(value, nameof(value));
        });
    }

    [Test]
    public void AgainstNegative_DoesNotThrowException()
    {
        const int value = 1;
        Assert.DoesNotThrow(() =>
        {
            Guard.AgainstNegative(value, nameof(value));
        });
    }
    [Test]
    public void AgainstZero_ThrowsException()
    {
        const int value = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Guard.AgainstZero(value, nameof(value));
        });
    }

    [Test]
    public void AgainstZero_DoesNotThrowException()
    {
        const int value = 1;
        Assert.DoesNotThrow(() =>
        {
            Guard.AgainstZero(value, nameof(value));
        });
    }
}