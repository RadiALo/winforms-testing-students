using System;

namespace Testing_students
{
    public static class Question
    {
        public static string GetContentTag(string Source, string Tag)
        {
            string Start = "<" + Tag + ">";
            string End = "<" + Tag + "/>";
            
            if (Source.Contains(Start) && Source.Contains(End))
            {
                return Source.Substring(Source.IndexOf(Start) + Start.Length, Source.IndexOf(End) - (Source.IndexOf(Start) + Start.Length));
            } else
            {
                throw new Exception();
            }
        }

        public static string GetContentTag(string Source, string Tag, out bool Exist)
        {
            string Start = "<" + Tag + ">";
            string End = "<" + Tag + "/>";

            if (Source.Contains(Start) && Source.Contains(End))
            {
                Exist = true;
                return Source.Substring(Source.IndexOf(Start) + Start.Length, Source.IndexOf(End) - (Source.IndexOf(Start) + Start.Length));
            }
            else
            {
                Exist = false;
                return "";
            }
        }
    }
}
