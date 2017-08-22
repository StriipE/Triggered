using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggered
{
    public class Parser
    {
        private List<string> queries;

        public Parser()
        {
            queries = new List<string>();
        }

        public void parseTrigger( string trigger )
        {
            lookForBooleansOperators( trigger );
        }

        private void lookForBooleansOperators( string trigger )
        {
            List<string> parenthesisQueries = new List<string>( parseParenthesis(trigger) );
            List<string> andQueries = new List<string>();

            for (int i = 0; i < parenthesisQueries.Count; i++)
            {
                List<string> tempQueries = new List<string>( findAndQueries(parenthesisQueries[i]) );
                foreach (string s in tempQueries)
                    andQueries.Add(s);
            }

            
            for (int i = 0; i < andQueries.Count; i++)
            {
                List<string> tempQueries = new List<string>( findOrQueries(andQueries[i]) );
                foreach( string s in tempQueries )
                    queries.Add(s);
            }

            for (int i = 0; i < queries.Count; i++)
            {
                Console.WriteLine(queries[i]);
            }
        }

        // And queries are split with the "A!" block
        private String[] findAndQueries( String trigger )
        {
            return trigger.Split(new string[] { "A!" }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Or queries are split with the "O!" block
        private String[] findOrQueries( String trigger )
        {
            return trigger.Split(new string[] { "O!" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private String[] parseParenthesis( String trigger )
        {
            String[] parsedParenthesis = trigger.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            return putParenthesisOnFront(parsedParenthesis);
        }

        // If a parenthesis is parsed, put the parenthesis operation to resolve on front
        // If no parenthesis are found, don't change anything
        private String[] putParenthesisOnFront( String[] parsedParenthesis )
        {
            String[] result = new String[parsedParenthesis.Length];
            if (parsedParenthesis.Length > 1)
            {
                result[0] = parsedParenthesis[1];
                result[1] = parsedParenthesis[0];
                return result;
            }
            else
                return parsedParenthesis;
            

        }
        public List<string> getQueries()
        {
            return this.queries;
        }

        public void emptyQueries()
        {
            this.queries = new List<string>();
        }
    }
}
