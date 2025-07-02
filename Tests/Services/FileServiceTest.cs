using ClassLibrary.Services;
using ClassLibrary.Services.Interfaces;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests.Services;

[TestFixture]
[TestOf(typeof(FileService))]
public class FileServiceTest
{
    private IFileService _service;
    private string _tempPath;
    private string _tempFile;
    private const string TestContent = "Test content";

    [SetUp]
    public void SetUp()
    {
        _service = new FileService();
        _tempPath = Path.GetTempPath();
        _tempFile = Path.Combine(_tempPath, Guid.NewGuid() + ".txt");
    }

    [TearDown]
    public void CleanUp()
    {
        if (File.Exists(_tempFile))
            File.Delete(_tempFile);
    }

    [Test]
    public void Save_CreatesFileWithContent()
    {
        _service.Save(TestContent, _tempFile);
        _service.TryRead(_tempFile, out var content);
        Assert.That(content, Is.EqualTo(TestContent));
    }

    [Test]
    public void Save_Throws_WhenContentIsNullOrEmpty()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => _service.Save(null, _tempFile));
            Assert.Throws<InvalidOperationException>(() => _service.Save(string.Empty, _tempFile));
        });
    }

    [Test]
    public void TryRead_ReturnsTrue_AndReadsContent_WhenFileExists()
    {
        _service.Save(TestContent, _tempFile);

        Assert.Multiple(() =>
        {
            Assert.That(_service.TryRead(_tempFile, out var content), Is.True);
            Assert.That(content, Is.EqualTo(TestContent));
        });
    }

    [Test]
    public void TryRead_ReturnsFalse_WhenFileDoesNotExist()
    {
        Assert.Multiple(() =>
            {
                Assert.That(_service.TryRead(_tempFile, out var content), Is.False);
                Assert.That(content, Is.Null);
            });
    }

    [Test]
    public void TryDelete_DeletesFile_WhenExists()
    {
        _service.Save(TestContent, _tempFile);
        Assert.That(_service.TryDelete(_tempFile), Is.True);
    }

    [Test]
    public void TryDelete_ReturnsFalse_WhenFileDoesNotExist()
    {
        Assert.That(_service.TryDelete(_tempFile), Is.False);
    }

    [Test]
    public void Exists_ReturnsTrue_WhenFileExists()
    {
        _service.Save(TestContent, _tempFile);
        Assert.That(_service.Exists(_tempFile), Is.True);
    }

    [Test]
    public void Exists_ReturnsFalse_WhenFileDoesNotExist()
    {
        Assert.That(_service.Exists(_tempFile), Is.False);
    }
}