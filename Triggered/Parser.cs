using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggered
{
    public class Parser
    {
        private String currentParsedTriger;
        private String[] queries;

        public Parser()
        {
            currentParsedTriger = "";
            queries = new String[100];
        }

        public void parseTrigger( String trigger )
        {
            this.currentParsedTriger = trigger;
            lookForBooleansOperators();
        }

        private void lookForBooleansOperators()
        {
            String[] andQueries = findAndQueries();
            queries.Concat(andQueries);
            for (int i = 0; i < andQueries.Length; i++)
            {
                Console.WriteLine(andQueries[i]);
            }

        }

        private String[] findAndQueries()
        {
            return this.currentParsedTriger.Split(new string[] { "AX" }, StringSplitOptions.None);
        }

        private String[] findOrQueries()
        {
            return this.currentParsedTriger.Split(new string[] { "OX" }, StringSplitOptions.None);
        }
    }
}
