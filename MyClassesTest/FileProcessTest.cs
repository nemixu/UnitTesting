using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:/NotExists.bad";

        public TestContext TestContext { get; set; }  

        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine("Checking File" + BAD_FILE_NAME);

            bool v = fp.FileExists(@"c:/windows/regedit.exe");
            fromCall = v;

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();
            TestContext.Write("Checking for a Null File");
            fp.FileExists(""); 
        }

        [TestMethod]
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
