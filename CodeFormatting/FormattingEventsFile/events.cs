namespace FormattingEventsFile
{
    using System;
    using System.Text;

    public class Events
    {
        private static StringBuilder output = new StringBuilder();

        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(output);
        }

        public static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (command[0] == 'A')
            {
                AddEvent(command);
                return true;
            }

            if (command[0] == 'D')
            {
                DeleteEvents(command);
                return true;
            }

            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }

            if (command[0] == 'E')
            {
                return false;
            }

            return false;
        }

        public static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        public static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);

            events.DeleteEvents(title);
        }

        public static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);

            events.AddEvent(date, title, location);
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }

        private static void GetParameters(
                    string commandForExecution,
                    string commandType,
                    out DateTime dateAndTime,
                    out string eventTitle,
                    out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                int startIndex = firstPipeIndex + 1;
                eventTitle = commandForExecution.Substring(startIndex).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                int startIndex = firstPipeIndex + 1;
                int length = lastPipeIndex - firstPipeIndex - 1;
                eventTitle = commandForExecution.Substring(startIndex, length).Trim();

                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }
    }
}