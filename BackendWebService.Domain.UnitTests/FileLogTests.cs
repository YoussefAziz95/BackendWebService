using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class FileLogTests
{
    [Fact]
    public void FileLog_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var fileLog = new FileLog();

        // Assert
        fileLog.Should().NotBeNull();
        fileLog.FileName.Should().BeNull();
        fileLog.FullPath.Should().BeNull();
        fileLog.Extention.Should().BeNull();
        fileLog.FileTypeId.Should().Be(0);
        fileLog.FileType.Should().BeNull();
        fileLog.IsActive.Should().BeTrue();
        fileLog.IsDeleted.Should().BeFalse();
        fileLog.IsSystem.Should().BeFalse();
        fileLog.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData("test.txt")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long file name that might exceed normal length expectations")]
    public void FileLog_FileName_ShouldBeSettable(string fileName)
    {
        // Arrange
        var fileLog = new FileLog();

        // Act
        fileLog.FileName = fileName;

        // Assert
        fileLog.FileName.Should().Be(fileName);
    }

    [Theory]
    [InlineData("C:\\temp\\test.txt")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Very long full path that might exceed normal length expectations")]
    public void FileLog_FullPath_ShouldBeSettable(string fullPath)
    {
        // Arrange
        var fileLog = new FileLog();

        // Act
        fileLog.FullPath = fullPath;

        // Assert
        fileLog.FullPath.Should().Be(fullPath);
    }

    [Theory]
    [InlineData(".txt")]
    [InlineData(".pdf")]
    [InlineData(".doc")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(".verylongextension")]
    public void FileLog_Extention_ShouldBeSettable(string extention)
    {
        // Arrange
        var fileLog = new FileLog();

        // Act
        fileLog.Extention = extention;

        // Assert
        fileLog.Extention.Should().Be(extention);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void FileLog_FileTypeId_ShouldBeSettable(int fileTypeId)
    {
        // Arrange
        var fileLog = new FileLog();

        // Act
        fileLog.FileTypeId = fileTypeId;

        // Assert
        fileLog.FileTypeId.Should().Be(fileTypeId);
    }

    [Fact]
    public void FileLog_FileType_ShouldBeSettable()
    {
        // Arrange
        var fileLog = new FileLog();
        var fileType = new FileType();

        // Act
        fileLog.FileType = fileType;

        // Assert
        fileLog.FileType.Should().Be(fileType);
    }

    [Fact]
    public void FileLog_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog
        {
            FileName = "test.txt",
            FullPath = "C:\\temp\\test.txt",
            Extention = ".txt",
            FileTypeId = 1
        };

        // Assert
        fileLog.FileName.Should().Be("test.txt");
        fileLog.FullPath.Should().Be("C:\\temp\\test.txt");
        fileLog.Extention.Should().Be(".txt");
        fileLog.FileTypeId.Should().Be(1);
        fileLog.IsActive.Should().BeTrue();
    }

    [Fact]
    public void FileLog_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType();
        var fileLog = new FileLog
        {
            FileName = "test.txt",
            FullPath = "C:\\temp\\test.txt",
            Extention = ".txt",
            FileTypeId = 1,
            FileType = fileType
        };

        // Assert
        fileLog.FileName.Should().Be("test.txt");
        fileLog.FullPath.Should().Be("C:\\temp\\test.txt");
        fileLog.Extention.Should().Be(".txt");
        fileLog.FileTypeId.Should().Be(1);
        fileLog.FileType.Should().Be(fileType);
    }

    [Fact]
    public void FileLog_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog
        {
            FileName = null,
            FullPath = null,
            Extention = null,
            FileTypeId = 1,
            FileType = null
        };

        // Assert
        fileLog.FileName.Should().BeNull();
        fileLog.FullPath.Should().BeNull();
        fileLog.Extention.Should().BeNull();
        fileLog.FileTypeId.Should().Be(1);
        fileLog.FileType.Should().BeNull();
    }

    [Fact]
    public void FileLog_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog
        {
            FileName = "",
            FullPath = "",
            Extention = "",
            FileTypeId = 1
        };

        // Assert
        fileLog.FileName.Should().Be("");
        fileLog.FullPath.Should().Be("");
        fileLog.Extention.Should().Be("");
        fileLog.FileTypeId.Should().Be(1);
    }

    [Fact]
    public void FileLog_WithZeroFileTypeId_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog
        {
            FileName = "test.txt",
            FullPath = "C:\\temp\\test.txt",
            Extention = ".txt",
            FileTypeId = 0
        };

        // Assert
        fileLog.FileName.Should().Be("test.txt");
        fileLog.FullPath.Should().Be("C:\\temp\\test.txt");
        fileLog.Extention.Should().Be(".txt");
        fileLog.FileTypeId.Should().Be(0);
    }

    [Fact]
    public void FileLog_WithNegativeFileTypeId_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog
        {
            FileName = "test.txt",
            FullPath = "C:\\temp\\test.txt",
            Extention = ".txt",
            FileTypeId = -1
        };

        // Assert
        fileLog.FileName.Should().Be("test.txt");
        fileLog.FullPath.Should().Be("C:\\temp\\test.txt");
        fileLog.Extention.Should().Be(".txt");
        fileLog.FileTypeId.Should().Be(-1);
    }

    [Fact]
    public void FileLog_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var fileLog = new FileLog { FileName = "test.txt" };

        // Act
        var result = fileLog.ToString();

        // Assert
        result.Should().Contain("FileLog");
    }

    [Fact]
    public void FileLog_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var fileLog = new FileLog();

        // Assert
        fileLog.Should().BeAssignableTo<BaseEntity>();
        fileLog.Should().BeAssignableTo<IEntity>();
        fileLog.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void FileLog_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var fileLog = new FileLog();
        var fileType = new FileType();

        // Act
        fileLog.FileName = "test.txt";
        fileLog.FullPath = "C:\\temp\\test.txt";
        fileLog.Extention = ".txt";
        fileLog.FileTypeId = 1;
        fileLog.FileType = fileType;

        // Assert
        fileLog.FileName.Should().Be("test.txt");
        fileLog.FullPath.Should().Be("C:\\temp\\test.txt");
        fileLog.Extention.Should().Be(".txt");
        fileLog.FileTypeId.Should().Be(1);
        fileLog.FileType.Should().Be(fileType);
    }
}
