using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kaz.Operations.Text.Tokenizing.Core
{
    internal class TokenRule<TokenType> where TokenType : Enum
    {
        internal TokenType Type { get; }
        private readonly string _pattern;
        private readonly Regex _regex;
        private readonly bool _isRegex;

        internal TokenRule(string pattern, TokenType type)
        {
            Type = type;
            _pattern = pattern;
            _isRegex = false;
        }

        internal TokenRule(Regex pattern, TokenType type)
        {
            Type = type;
            _regex = pattern;
            _isRegex = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Token<TokenType>? TryMatch(string source, int position)
        {
            if (_isRegex)
            {
                var match = _regex!.Match(source, position);

                if (match.Success && match.Index == position)
                {
                    return new Token<TokenType>(Type, match.Value);
                }
            }
            else
            {
                if (source.AsSpan(position).StartsWith(_pattern))
                {
                    return new Token<TokenType>(Type, _pattern!);
                }
            }

            return null;
        }

    }
}
