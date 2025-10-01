using Xunit;
using FluentAssertions;
using Application.Utilities;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System.Text;
using BackendWebService.Application.UnitTests.TestUtilities;

namespace BackendWebService.Application.UnitTests.Handlers;

public class FileHandlerTests : IDisposable
{
    private readonly FileHandler _fileHandler;
    private readonly string _testDirectory;
    private readonly string _testFilePath;

    public FileHandlerTests()
    {
        _fileHandler = new FileHandler();
        _testDirectory = Path.Combine(Path.GetTempPath(), "FileHandlerTests");
        _testFilePath = Path.Combine(_testDirectory, "testfile.txt");
        
        // Clean up any existing test directory
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }

    [Fact]
    public async Task Upload_WithValidFile_ShouldUploadFileSuccessfully()
    {
        // Arrange
        var fileContent = "test content";
        var fileName = "test.txt";
        var fileBytes = Encoding.UTF8.GetBytes(fileContent);
        var fileStream = new MemoryStream(fileBytes);
        
        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.FileName).Returns(fileName);
        mockFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns((Stream stream, CancellationToken token) => fileStream.CopyToAsync(stream, token));

        // Act
        var result = await _fileHandler.Upload(mockFile.Object, _testDirectory);

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().StartWith(_testDirectory);
        result.Should().EndWith(".txt");
        
        // Verify file was created
        File.Exists(result).Should().BeTrue();
        
        // Verify file content
        var actualContent = await File.ReadAllTextAsync(result);
        actualContent.Should().Be(fileContent);
    }

    [Fact]
    public async Task Upload_WithNonExistentDirectory_ShouldCreateDirectory()
    {
        // Arrange
        var nonExistentDirectory = Path.Combine(_testDirectory, "subdirectory");
        var fileContent = "test content";
        var fileName = "test.txt";
        var fileBytes = Encoding.UTF8.GetBytes(fileContent);
        var fileStream = new MemoryStream(fileBytes);
        
        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.FileName).Returns(fileName);
        mockFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns((Stream stream, CancellationToken token) => fileStream.CopyToAsync(stream, token));

        // Act
        var result = await _fileHandler.Upload(mockFile.Object, nonExistentDirectory);

        // Assert
        Directory.Exists(nonExistentDirectory).Should().BeTrue();
        File.Exists(result).Should().BeTrue();
    }

    [Fact]
    public async Task Upload_ShouldGenerateUniqueFileName()
    {
        // Arrange
        var fileContent = "test content";
        var fileName = "test.txt";
        var fileBytes = Encoding.UTF8.GetBytes(fileContent);
        var fileStream = new MemoryStream(fileBytes);
        
        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.FileName).Returns(fileName);
        mockFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns((Stream stream, CancellationToken token) => fileStream.CopyToAsync(stream, token));

        // Act
        var result1 = await _fileHandler.Upload(mockFile.Object, _testDirectory);
        
        // Wait a moment to ensure different timestamp
        await Task.Delay(1000);
        
        var result2 = await _fileHandler.Upload(mockFile.Object, _testDirectory);

        // Assert
        result1.Should().NotBe(result2);
        File.Exists(result1).Should().BeTrue();
        File.Exists(result2).Should().BeTrue();
    }

    [Fact]
    public void Delete_WithExistingFile_ShouldDeleteFile()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");

        // Act
        _fileHandler.Delete(_testFilePath);

        // Assert
        File.Exists(_testFilePath).Should().BeFalse();
    }

    [Fact]
    public void Delete_WithNonExistentFile_ShouldNotThrow()
    {
        // Arrange
        var nonExistentFile = Path.Combine(_testDirectory, "nonexistent.txt");

        // Act & Assert
        var action = () => _fileHandler.Delete(nonExistentFile);
        action.Should().NotThrow();
    }

    [Fact]
    public void Move_WithValidPaths_ShouldMoveFile()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");
        var newPath = Path.Combine(_testDirectory, "moved.txt");

        // Act
        var result = _fileHandler.Move(_testFilePath, newPath);

        // Assert
        result.Should().BeTrue();
        File.Exists(_testFilePath).Should().BeFalse();
        File.Exists(newPath).Should().BeTrue();
        
        var content = File.ReadAllText(newPath);
        content.Should().Be("test content");
    }

    [Fact]
    public void Move_WithNonExistentSourceFile_ShouldReturnFalse()
    {
        // Arrange
        var nonExistentFile = Path.Combine(_testDirectory, "nonexistent.txt");
        var newPath = Path.Combine(_testDirectory, "moved.txt");

        // Act
        var result = _fileHandler.Move(nonExistentFile, newPath);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Move_WithExistingDestinationFile_ShouldReturnFalse()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");
        var existingFile = Path.Combine(_testDirectory, "existing.txt");
        File.WriteAllText(existingFile, "existing content");

        // Act
        var result = _fileHandler.Move(_testFilePath, existingFile);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Move_WithNonExistentDestinationDirectory_ShouldCreateDirectory()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");
        var subDirectory = Path.Combine(_testDirectory, "subdir");
        var newPath = Path.Combine(subDirectory, "moved.txt");

        // Act
        var result = _fileHandler.Move(_testFilePath, newPath);

        // Assert
        result.Should().BeTrue();
        Directory.Exists(subDirectory).Should().BeTrue();
        File.Exists(newPath).Should().BeTrue();
    }

    [Fact]
    public void Exists_WithExistingFile_ShouldReturnTrue()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");

        // Act
        var result = _fileHandler.Exists(_testFilePath);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Exists_WithNonExistentFile_ShouldReturnFalse()
    {
        // Arrange
        var nonExistentFile = Path.Combine(_testDirectory, "nonexistent.txt");

        // Act
        var result = _fileHandler.Exists(nonExistentFile);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void DownloadFile_WithExistingFile_ShouldReturnFilePath()
    {
        // Arrange
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(_testFilePath, "test content");

        // Act
        var result = _fileHandler.DownloadFile(_testFilePath);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(_testFilePath);
    }

    [Fact]
    public void DownloadFile_WithNonExistentFile_ShouldReturnNull()
    {
        // Arrange
        var nonExistentFile = Path.Combine(_testDirectory, "nonexistent.txt");

        // Act
        var result = _fileHandler.DownloadFile(nonExistentFile);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetFile_WithExistingFile_ShouldReturnFilePath()
    {
        // Arrange
        var fileName = "test.txt";
        var testFile = Path.Combine(_testDirectory, fileName);
        Directory.CreateDirectory(_testDirectory);
        File.WriteAllText(testFile, "test content");

        // Act
        var result = _fileHandler.GetFile(fileName);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(testFile);
    }

    [Fact]
    public void GetFile_WithNonExistentFile_ShouldReturnNull()
    {
        // Arrange
        var fileName = "nonexistent.txt";

        // Act
        var result = _fileHandler.GetFile(fileName);

        // Assert
        result.Should().BeNull();
    }

    public void Dispose()
    {
        // Clean up test directory
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);
        }
    }
}
