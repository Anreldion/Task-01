using ClassLibrary.Services;
using NUnit.Framework;
using System.IO;
using ClassLibrary.Services.Interfaces;
using System;

namespace Tests.Services;

[TestFixture]
[TestOf(typeof(FolderService))]
public class FolderServiceTest
{
    private IFolderService _service = new FolderService();
    private string _tempDir;

    [SetUp]
    public void SetUp()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    }

    [TearDown]
    public void CleanUp()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Test]
    public void Create_CreatesDirectory_WhenNotExists()
    {
        _service.Create(_tempDir);
        Assert.That(_service.Exists(_tempDir), Is.True);
    }

    [Test]
    public void Create_Throws_WhenPathIsNullOrEmpty()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(()=>_service.Create(null));
            Assert.Throws<InvalidOperationException>(() => _service.Create(string.Empty));
        });
    }

    [Test]
    public void TryDelete_DeletesDirectory_WhenExists()
    {
        Directory.CreateDirectory(_tempDir);
        Assert.That(_service.TryDelete(_tempDir), Is.True);
    }

    [Test]
    public void TryDelete_ReturnsFalse_WhenDirectoryDoesNotExist()
    {
        Assert.That(_service.TryDelete(_tempDir), Is.False);
    }

    [Test]
    public void Exists_ReturnsTrue_WhenDirectoryExists()
    {
        Directory.CreateDirectory(_tempDir);
        Assert.That(_service.Exists(_tempDir), Is.True);
    }

    [Test]
    public void Exists_ReturnsFalse_WhenDirectoryDoesNotExist()
    {
        Assert.That(_service.Exists(_tempDir), Is.False);
    }
}