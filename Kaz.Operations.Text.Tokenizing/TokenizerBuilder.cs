using Kaz.Operations.Text.Tokenizing.Core;
using System.Text.RegularExpressions;

namespace Kaz.Operations.Text.Tokenizing
{
    /// <summary>
    /// Provides a fluent API builder for the tokenizer class.
    /// </summary>
    /// <typeparam name="TokenType">Types of tokens.</typeparam>
    public class TokenizerBuilder<TokenType> where TokenType : Enum
    {
        private readonly List<TokenRule<TokenType>> _rules = new();

        /// <summary>
        /// Adds a string rule that the tokenizer will use to find all the pattern matches.
        /// </summary>
        /// <param name="pattern">Pattern to look for.</param>
        /// <param name="type">Type of the match value.</param>
        /// <returns>The configured <see cref="TokenizerBuilder{TokenType}."/></returns>
        public TokenizerBuilder<TokenType> AddRule(string pattern, TokenType type)
        {
            _rules.Add(new TokenRule<TokenType>(pattern, type));
            return this;
        }

        /// <summary>
        /// Adds a regular expression rule that the tokenizer will use to find all the pattern matches.
        /// </summary>
        /// <param name="pattern">Pattern to look for.</param>
        /// <param name="type">Type of the match value.</param>
        /// <returns>The configured <see cref="TokenizerBuilder{TokenType}."/></returns>
        public TokenizerBuilder<TokenType> AddRule(Regex pattern, TokenType type)
        {
            _rules.Add(new TokenRule<TokenType>(pattern, type));
            return this;
        }

        /// <summary>
        /// Builds a new <see cref="Tokenizer{TokenType}"/> instance.
        /// </summary>
        /// <returns>The configured tokenizer.</returns>
        public Tokenizer<TokenType> Build()
        {
            return new Tokenizer<TokenType>(_rules);
        }
    }
}