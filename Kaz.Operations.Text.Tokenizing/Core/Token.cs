namespace Kaz.Operations.Text.Tokenizing.Core
{
    public struct Token<TokenType> where TokenType : Enum
    {
        public TokenType Type { get; init; }
        public string Value { get; init; }
        internal Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"Type: {Type}\n" + $"Value: {Value}";
        }
    }
}