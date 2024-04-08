using Microsoft.AspNetCore.Routing;
using Moq;
using OnlineLpk12.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Generic;
using Moq;


namespace Helpers_Test
{
    [TestClass]
    public class SparcFileSystemHelperTests
    {
        [TestMethod]
        public void GetTree_ReturnsCorrectTreeStructure()
        {
            // Arrange
            var folders = new List<string> { "folder1", "folder2", "folder3" };
            var files = new List<string> { "folder1/file1", "folder2/file2", "folder3/file3" };

            // Act
            var tree = SparcFileSystemHelper.GetTree(folders, files);

            // Assert
            Assert.IsNotNull(tree);
            // Add more assertions based on the expected structure of the tree
        }

        [TestMethod]
        public void GetFolderNameFromFolderUrl_ReturnsCorrectFolderName()
        {
            // Arrange
            var folderUrl = "folder1/subfolder1";

            // Act
            var folderName = SparcFileSystemHelper.GetFolderNameFromFolderUrl(folderUrl);

            // Assert
            Assert.AreEqual("subfolder1", folderName);
        }

        [TestMethod]
        public void GetFileNameFromFileUrl_ReturnsCorrectFileName()
        {
            // Arrange
            var fileUrl = "folder1/file1.txt";

            // Act
            var fileName = SparcFileSystemHelper.GetFileNameFromFileUrl(fileUrl);

            // Assert
            Assert.AreEqual("file1.txt", fileName);
        }

        [TestMethod]
        public void GetParentUrlFromFolderUrl_ReturnsCorrectParentUrl()
        {
            // Arrange
            var folderUrl = "folder1/subfolder1";

            // Act
            var parentUrl = SparcFileSystemHelper.GetParentUrlFromFolderUrl(folderUrl);

            // Assert
            Assert.AreEqual("folder1", parentUrl);
        }

        [TestMethod]
        public void GetFolderUrlFromFileUrl_ReturnsCorrectFolderUrl()
        {
            // Arrange
            var fileUrl = "folder1/subfolder1/file1.txt";

            // Act
            var folderUrl = SparcFileSystemHelper.GetFolderUrlFromFileUrl(fileUrl);

            // Assert
            Assert.AreEqual("folder1/subfolder1", folderUrl);
        }

    }
}

