namespace EventCalendar.Utiltiies
{
    public static class Validator
    {
        //validates the event title
        public static bool validateTitle(string title)
        {
            return title.Length < 50 && title != null ? true : false;

        }
        //validates the event description
        public static bool validateDescription(string description)
        {
            return description.Length < 500 && description != null ? true : false;
        }


    }
}
