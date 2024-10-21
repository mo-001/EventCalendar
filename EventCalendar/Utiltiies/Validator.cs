namespace EventCalendar.Utiltiies
{
    public static class Validator
    {
        //validates the event title
        public static bool validateTitle(string title)
        {
            return title.Length < 50 ? true : false;

        }

        public static bool validateDescription(string description)
        {
            return description.Length < 500 ? true : false;
        }


    }
}
