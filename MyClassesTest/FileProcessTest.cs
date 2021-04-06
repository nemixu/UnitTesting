using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {

        private const string BAD_FILE_NAME = @"C:/NotExists.bad";
        // test initialization methods and cleanups.
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


        // Testing methods 


        [TestMethod]
        [Description("Check to see if a file exists.")]
        [Owner("Stevo")]
        public void FileNameDoesExist() 
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            
            TestContext.WriteLine("Checking File" + _GoodFileName);

            bool v = fp.FileExists(_GoodFileName);

            fromCall = v;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does not exist.")]
        [Owner("Stevo")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.Write("Checking for a Null File ");

            fromCall = fp.FileExists("Checking file" + BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Description("Check for a thrown ArgNullException using ExpectedException")]
        [Owner("Stevo")]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            TestContext.Write("Checking for a Null File");

            fp.FileExists(""); 
        }

        [TestMethod]
        [Description("Check for a thrown ArgNullException using try...catch.")]
        [Owner("Stevo")]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.Write("Checking for a Null File");
                fp.FileExists("");
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("Call to FileExists() did not thrown an ArgumentNullException");
        }
    }
}
