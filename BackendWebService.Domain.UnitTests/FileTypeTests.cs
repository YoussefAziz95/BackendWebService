using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class FileTypeTests
{
    [Fact]
    public void FileType_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var fileType = new FileType();

        // Assert
        fileType.Should().NotBeNull();
        fileType.Type.Should().Be((FileTypeEnum)0);
        fileType.Extentions.Should().BeNull();
        fileType.FileLogs.Should().BeNull();
        fileType.Validators.Should().BeNull();
        fileType.IsActive.Should().BeTrue();
        fileType.IsDeleted.Should().BeFalse();
        fileType.IsSystem.Should().BeFalse();
        fileType.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(FileTypeEnum.Video)]
    [InlineData(FileTypeEnum.Audio)]
    [InlineData(FileTypeEnum.Document)]
    [InlineData(FileTypeEnum.Archive)]
    [InlineData(FileTypeEnum.Executable)]
    [InlineData(FileTypeEnum.Other)]
    [InlineData(FileTypeEnum.Image)]
    public void FileType_Type_ShouldBeSettable(FileTypeEnum type)
    {
        // Arrange
        var fileType = new FileType();

        // Act
        fileType.Type = type;

        // Assert
        fileType.Type.Should().Be(type);
    }

    [Theory]
    [InlineData(".mp4,.avi,.mov")]
    [InlineData(".mp3,.wav,.flac")]
    [InlineData(".pdf,.doc,.docx")]
    [InlineData(".zip,.rar,.7z")]
    [InlineData(".exe,.msi,.app")]
    [InlineData(".jpg,.png,.gif")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(".very.long.extension.list.that.might.exceed.normal.length.expectations")]
    public void FileType_Extentions_ShouldBeSettable(string extentions)
    {
        // Arrange
        var fileType = new FileType();

        // Act
        fileType.Extentions = extentions;

        // Assert
        fileType.Extentions.Should().Be(extentions);
    }

    [Fact]
    public void FileType_FileLogs_ShouldBeSettable()
    {
        // Arrange
        var fileType = new FileType();
        var fileLog = new FileLog();

        // Act
        fileType.FileLogs = new List<FileLog> { fileLog };

        // Assert
        fileType.FileLogs.Should().NotBeNull();
        fileType.FileLogs.Should().Contain(fileLog);
    }

    [Fact]
    public void FileType_Validators_ShouldBeSettable()
    {
        // Arrange
        var fileType = new FileType();
        var validator = new FileFieldValidator();

        // Act
        fileType.Validators = new List<FileFieldValidator> { validator };

        // Assert
        fileType.Validators.Should().NotBeNull();
        fileType.Validators.Should().Contain(validator);
    }

    [Fact]
    public void FileType_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType
        {
            Type = FileTypeEnum.Document,
            Extentions = ".pdf,.doc,.docx"
        };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Document);
        fileType.Extentions.Should().Be(".pdf,.doc,.docx");
        fileType.IsActive.Should().BeTrue();
    }

    [Fact]
    public void FileType_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileLog = new FileLog();
        var validator = new FileFieldValidator();
        var fileType = new FileType
        {
            Type = FileTypeEnum.Image,
            Extentions = ".jpg,.png,.gif,.bmp",
            FileLogs = new List<FileLog> { fileLog },
            Validators = new List<FileFieldValidator> { validator }
        };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Image);
        fileType.Extentions.Should().Be(".jpg,.png,.gif,.bmp");
        fileType.FileLogs.Should().Contain(fileLog);
        fileType.Validators.Should().Contain(validator);
    }

    [Fact]
    public void FileType_WithNullExtentions_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType
        {
            Type = FileTypeEnum.Other,
            Extentions = null
        };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Other);
        fileType.Extentions.Should().BeNull();
    }

    [Fact]
    public void FileType_WithEmptyExtentions_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType
        {
            Type = FileTypeEnum.Other,
            Extentions = ""
        };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Other);
        fileType.Extentions.Should().Be("");
    }

    [Fact]
    public void FileType_WithNullCollections_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType
        {
            Type = FileTypeEnum.Document,
            Extentions = ".pdf",
            FileLogs = null,
            Validators = null
        };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Document);
        fileType.Extentions.Should().Be(".pdf");
        fileType.FileLogs.Should().BeNull();
        fileType.Validators.Should().BeNull();
    }

    [Theory]
    [InlineData(FileTypeEnum.Video, ".mp4,.avi,.mov")]
    [InlineData(FileTypeEnum.Audio, ".mp3,.wav,.flac")]
    [InlineData(FileTypeEnum.Document, ".pdf,.doc,.docx")]
    [InlineData(FileTypeEnum.Archive, ".zip,.rar,.7z")]
    [InlineData(FileTypeEnum.Executable, ".exe,.msi,.app")]
    [InlineData(FileTypeEnum.Image, ".jpg,.png,.gif")]
    [InlineData(FileTypeEnum.Other, ".unknown")]
    public void FileType_TypeAndExtentions_ShouldBeSettable(FileTypeEnum type, string extentions)
    {
        // Arrange
        var fileType = new FileType();

        // Act
        fileType.Type = type;
        fileType.Extentions = extentions;

        // Assert
        fileType.Type.Should().Be(type);
        fileType.Extentions.Should().Be(extentions);
    }

    [Fact]
    public void FileType_WithDefaultEnumValue_ShouldBeCreatable()
    {
        // Arrange & Act
        var fileType = new FileType
        {
            Type = (FileTypeEnum)0,
            Extentions = ".unknown"
        };

        // Assert
        fileType.Type.Should().Be((FileTypeEnum)0);
        fileType.Extentions.Should().Be(".unknown");
    }

    [Fact]
    public void FileType_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var fileType = new FileType { Type = FileTypeEnum.Document };

        // Act
        var result = fileType.ToString();

        // Assert
        result.Should().Contain("FileType");
    }

    [Fact]
    public void FileType_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var fileType = new FileType();

        // Assert
        fileType.Should().BeAssignableTo<BaseEntity>();
        fileType.Should().BeAssignableTo<IEntity>();
        fileType.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void FileType_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var fileType = new FileType();
        var fileLog = new FileLog();
        var validator = new FileFieldValidator();

        // Act
        fileType.Type = FileTypeEnum.Image;
        fileType.Extentions = ".jpg,.png,.gif";
        fileType.FileLogs = new List<FileLog> { fileLog };
        fileType.Validators = new List<FileFieldValidator> { validator };

        // Assert
        fileType.Type.Should().Be(FileTypeEnum.Image);
        fileType.Extentions.Should().Be(".jpg,.png,.gif");
        fileType.FileLogs.Should().Contain(fileLog);
        fileType.Validators.Should().Contain(validator);
    }
}
