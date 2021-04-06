using System.Collections.Generic;  

namespace MyClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first,
                                   string last,
                                   bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else { ret = new Employee();
                }

                // Assign Variables
                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Paul", LastName = "Doe", });
            people.Add(new Person() { FirstName = "John", LastName = "Dope", });
            people.Add(new Person() { FirstName = "Hairy", LastName = "Jim", });

            return people;
        }
    }
}
