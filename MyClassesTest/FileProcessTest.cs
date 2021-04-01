﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        
        private const string BAD_FILE_NAME = @"C:/NotExists.bad";

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

        [TestMethod]
        public void FileNameDoesExist() 
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();

            if (!string.IsNullOrEmpty(_GoodFileName))
            {
                //Creating a 'Good' file.
                File.AppendAllText(_GoodFileName, "Some Text");
            }

            TestContext.WriteLine("Checking File" + _GoodFileName);

            bool v = fp.FileExists(_GoodFileName);

            fromCall = v;

            //delete the file 

            if (File.Exists(_GoodFileName))
            {
                File.Delete(_GoodFileName);
            }

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.Write("Checking for a Null File");

            fromCall = fp.FileExists("Checking file" + BAD_FILE_NAME);

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
