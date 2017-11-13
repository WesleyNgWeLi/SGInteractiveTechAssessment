using Microsoft.VisualStudio.TestTools.UnitTesting;
using SG_Tech_Assessment;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        YearHelper YH;
        List<Person> dataModel;

        [TestInitialize]
        public void SetUp()
        {
            YH = new YearHelper();
            dataModel = new List<Person>();
        }

        [TestMethod]
        public void PopulateDataShouldReturnCountOf5()
        {
            YH.PopulateData(dataModel);
            Assert.IsTrue(dataModel.Count == 5);
        }

        [TestMethod]
        public void PopulateArrayShouldReturnPopulatedArrayGivenSetInput()
        {
            int[] testArray = new int[100];
            YH.PopulateArray(1900, 1905, testArray);
            Assert.IsTrue(testArray[0] == 1);
            Assert.IsTrue(testArray[1] == 1);
            Assert.IsTrue(testArray[2] == 1);
            Assert.IsTrue(testArray[3] == 1);
            Assert.IsTrue(testArray[4] == 1);
            Assert.IsTrue(testArray[5] == 1);
        }

        [TestMethod]
        public void GetLargestValueAndIndexShouldReturnIndex2AndValue5()
        {
            int[] testArr = new int[] { 1, 2, 5, 4, 1 };
            Tuple<int, int> result = YH.GetLargestValueAndIndex(testArr);
            Assert.IsTrue(result.Item1 == 2);
            Assert.IsTrue(result.Item2 == 5);
        }

        [TestMethod]
        public void GetLargestIndexShouldReturnIndex2()
        {
            int[] testArr = new int[] { 1, 2, 5, 4, 1 };
            int result = YH.GetLargestIndex(testArr);
            Assert.IsTrue(result == 2);
        }
    }
}
