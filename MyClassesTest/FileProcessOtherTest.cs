using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In ClassInitiaize() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //todo cleanup after all the tests in class.
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() Method");
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating file: " + _GoodFileName);
                    //creating the good file.
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In TestCleanup() method");

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                //Delete the file
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file:" + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreEqualTest()
        {
            var str1 = "Paul";
            var str2 = "paul";
            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        public void AreNotEqual()
        {
            var str1 = "Paul";
            var str2 = "John";
            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File {0} Does not Exist.", _GoodFileName);
        }

        
    }
}
