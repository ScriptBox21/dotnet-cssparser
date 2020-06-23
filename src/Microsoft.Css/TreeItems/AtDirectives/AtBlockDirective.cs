using Microsoft.WebTools.Languages.Css.Parser;
using Microsoft.WebTools.Languages.Css.Tokens;
using Microsoft.WebTools.Languages.Shared.Text;

namespace Microsoft.WebTools.Languages.Css.TreeItems.AtDirectives
{
    /// <summary>
    /// In the form: @item1 item2 ... { ... }
    /// </summary>
    public abstract class AtBlockDirective : AtDirective
    {
        /// <summary>
        /// This is null if the block couldn't be parsed
        /// </summary>
        internal abstract BlockItem Block { get; }

        protected AtBlockDirective()
        {
        }

        /// <summary>
        /// True if the closing curly brace is missing.
        /// </summary>
        internal override bool IsUnclosed
        {
            get { return Block != null && Block.IsUnclosed; }
        }

        /// <summary>
        /// Helper function for derived classes to parse their block
        /// </summary>
        protected bool ParseBlock(BlockItem block, ItemFactory itemFactory, ITextProvider text, TokenStream tokens)
        {
            if (tokens.CurrentToken.TokenType == CssTokenType.OpenCurlyBrace)
            {
                if (block.Parse(itemFactory, text, tokens))
                {
                    Children.Add(block);
                    return true;
                }
            }
            else
            {
                Children.AddParseError(ParseErrorType.OpenCurlyBraceMissing);
            }

            return false;
        }
    }
}
