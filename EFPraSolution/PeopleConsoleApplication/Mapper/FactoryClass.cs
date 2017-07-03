public class FactoryClass
    {
        public static List<Person> GetPersonEntityList(List<PersonDto> personlist)
        {
            var personEntityList = new List<Person>();
           personlist.ForEach(a => personEntityList.Add(GetPersonEntity(a)));
            return personEntityList;
           
        }
        public static List<PersonDto> GetPersonDtoList(List<Person> personlist)
        {
            var personDtoList = new List<PersonDto>();
            personlist.ForEach(a => personDtoList.Add(GetPersonEntity(a)));
            return personDtoList;
        }
        public static Person GetPersonEntity(PersonDto person)
        {
            return new Person() { Id=person.Id, Name=person.Name, RegistredOn=person.RegistredOn };
        }
        public static PersonDto GetPersonDot(Person person)
        {
            return new PersonDto() { Id = person.Id, Name = person.Name, RegistredOn = person.RegistredOn };
        }
    }
