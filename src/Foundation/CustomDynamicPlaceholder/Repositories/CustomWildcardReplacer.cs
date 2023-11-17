using Sitecore.XA.Foundation.DynamicPlaceholders.Repositories;
using System.Text.RegularExpressions;

namespace CustomDynamicPlaceholder.Repositories
{
    public class CustomWildcardReplacer : WildcardReplacer
    {
        private static Regex _r1;
        static CustomWildcardReplacer()
        {
            _r1 = new Regex("(.)*-([0-9]+)-([\\w\\{\\}\\*]+)", RegexOptions.Compiled);
        }
        public override string Resolve(string key)
        {
            string path;
            string last;
            this.SplitPlaceholderKey(key, out path, out last);
            if(_r1.Match(last).Success)
                return path + last;
            return base.Resolve(key);
        }
    }
}