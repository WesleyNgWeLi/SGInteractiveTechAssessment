using System;
using System.Collections.Generic;
using System.Linq;

namespace SG_Tech_Assessment
{
    //Simple data model to hold a persons birth and death year.
    //Done this way specifically to be more pragmatic
    public class Person
    {
        public int birth { get; set; }
        public int death { get; set; }

        public Person(int _birth, int _death)
        {
            birth = _birth;
            death = _death;
        }
    }
    public class YearHelper
    {

        /// <summary>
        /// Populates a list of Persons, done this way to adjust data easily. Could have been a file read in or anything else,
        /// just found this to be easy for illustrations
        /// List/Classes are passed by ref by default so no need for the ref handler
        /// </summary>
        /// <param name="listOfYearModel"></param>
        public void PopulateData(List<Person> listOfYearModel)
        {
            listOfYearModel.Add(new Person(1900, 1950));
            listOfYearModel.Add(new Person(1910, 1950));
            listOfYearModel.Add(new Person(1920, 1950));
            listOfYearModel.Add(new Person(1930, 1950));
            listOfYearModel.Add(new Person(1940, 1950));
        }

        /// <summary>
        /// Takes in a birth year and death year and populates the arrModel
        /// </summary>
        /// <param name="b"></param>
        /// <param name="d"></param>
        /// <param name="arrModel"></param>
        public void PopulateArray(int b, int d, int[] arrModel)
        {
            //For loop iterates through the years from birth to death and increments it by 1 representing a person
            //This loop increments the death year, so long as he lived a day in his death year he is counted as alive that year
            for(int i = b; i <= d; i++)
            {
                //subtracting the 1900 keeps the array within its declared limits as the years were limited from 1900 to 2000
                //could have subtracted b and d but decided that this was less lines and rather simple
                arrModel[i - 1900]++;
            }
        }
        /// <summary>
        /// returns the highest value as well as index of highest value of an array in the form of a Tuple
        /// Item 1 being the index and 2 being the value
        /// </summary>
        /// <param name="arrModel"></param>
        /// <returns></returns>
        public Tuple<int, int> GetLargestValueAndIndex(int[] arrModel)
        {
            int maxCount = arrModel.Max();
            int maxIndex = arrModel.ToList().IndexOf(maxCount);
            return Tuple.Create(maxIndex, maxCount);
        }


        public void PrintResult(int year, int count)
        {
            Console.WriteLine(string.Format(@"The year with the most living people is {0} with {1} living people", year, count));
            Console.ReadKey();
        }

        public void GetMostPopulatedYear()
        {
            //list of persons to hold the dataModel representing all the people who lived
            List<Person> dataModel = new List<Person>();

            //array to host the tally of living people, each index represents a year starting from 1900(00) to 2000(100)
            int[] arrTallyOfLivingPeople = new int[100];

            //could have been eliminated if I did PrintResult(GetIndexOfLargestValue(arrTallyOfLivingPeople)) but I decided this would be easier
            //to read
            Tuple<int, int> result;

            PopulateData(dataModel);

            //iterates through the dataModel and populates the array
            foreach (Person p in dataModel)
            {
                PopulateArray(p.birth, p.death, arrTallyOfLivingPeople);
            }

            result = GetLargestValueAndIndex(arrTallyOfLivingPeople);

            PrintResult(result.Item1 + 1900, result.Item2);
        }
    }
}
