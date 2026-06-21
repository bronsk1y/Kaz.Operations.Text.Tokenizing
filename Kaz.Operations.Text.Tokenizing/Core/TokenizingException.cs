namespace Kaz.Operations.Text.Tokenizing.Core
{
    /// <summary>
    /// An exception used by the <see cref="Tokenizer{TokenType}"/> class.
    /// </summary>
    internal class TokenizingException : Exception 
    {
        internal TokenizingException(string message)
        {
        }
    }
}
