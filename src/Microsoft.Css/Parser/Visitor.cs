using System;

namespace Microsoft.WebTools.Languages.Css.Parser
{
    public enum VisitItemResult
    {
        Continue, // recurse into children
        SkipChildren, // don't recurse into children
        Cancel, // stop iterating now (and return false from the Accept function)
    }

    public interface ICssSimpleTreeVisitor
    {
        VisitItemResult Visit(ParseItem parseItem);
    }

    /// <summary>
    /// Helper for using a function delegate as a CSS tree visitor
    /// </summary>
    public sealed class CssTreeVisitor : ICssSimpleTreeVisitor
    {
        private readonly Func<ParseItem, VisitItemResult> _func;

        public CssTreeVisitor(Func<ParseItem, VisitItemResult> func)
        {
            _func = func;
        }

        VisitItemResult ICssSimpleTreeVisitor.Visit(ParseItem parseItem)
        {
            return _func(parseItem);
        }
    }
}
