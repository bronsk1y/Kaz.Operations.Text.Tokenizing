using Kaz.Operations.Text.Tokenizing.Core;

namespace Kaz.Operations.Text.Tokenizing
{
    /// <summary>
    /// Provides methods for tokenizing.
    /// </summary>
    /// <typeparam name="TokenType">Types of tokens.</typeparam>
    public class Tokenizer<TokenType> where TokenType : Enum
    {
        private readonly List<TokenRule<TokenType>> _rules = new();

        internal Tokenizer(List<TokenRule<TokenType>> tokenRules) 
        { 
            _rules = tokenRules;
        }

        /// <summary>
        /// Analyzes the provided text for any matching patterns, converting them into tokens.
        /// </summary>
        /// <param name="text">Text to analyse.</param>
        /// <returns>The list with all tokens.</returns>
        /// <exception cref="TokenizingException">Thrown when no patterns were matched.</exception>
        public List<Token<TokenType>?> Tokenize(string text)
        {
            var tokens = new List<Token<TokenType>?>();

            if (_rules != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    bool matchFound = false;

                    foreach (var rule in _rules)
                    {
                        var token = rule.TryMatch(text, i);

                        if (token != null)
                        {
                            tokens.Add(token);
                            i += token.Value.Value.Length;
                            matchFound = true;
                            break;
                        }
                    }

                    if (!matchFound)
                    {
                        throw new TokenizingException("No tokens in the provided text were matched");
                    }
                }
            }

            return tokens;
        }
    }
}
