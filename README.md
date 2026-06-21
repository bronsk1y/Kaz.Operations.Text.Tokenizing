# Kaz.Operations.Text.RegularExpressions

## About
This library extends the Kaz.Operations.Text possibilities by adding a tokenizer class. This library targets **.NET 8** and **.NET Framework 4.7.2.**

## Features
- Adds a tokenizer class.
- Adds a fluent API builder to configure and build the tokenizer class.

## How to use

```csharp
using System;
using Kaz.Operations.Text.Tokenizing;

class Program 
{
	enum Tokens
	{
		String,
		Number,
		Boolean
	}

	static void Main(string[] args)
	{
		var builder = new TokenizerBuilder<Tokens>();

		builder.AddRule("Hello", Tokens.String) // Adds a rule for matching patterns
			   .AddRule("123", Tokens.Number)
			   .AddRule("true", Tokens.Boolean);
		
		var tokenizer = builder.Build(); // Returns a new tokenizer class instance

		string text = "Hello 123 true";
		var tokens = tokenizer.Tokenize(text); // Returns all matched tokens

		foreach (var token in tokens)
		{
			Console.WriteLine(token.ToString());
		}
	}
}
```

## Main Classes & Structures

The main classes are:

- **`TokenizerBuilder`**
- `Tokenizer`

The main structures are:

- **`Token`**

## Licence

Kaz.Operations.Text.Tokenizing is released as an open source project under the [MIT Licence](https://licenses.nuget.org/MIT).

## Feedback & Contributing

You can report a bug or contribute at [the GitHub repository](https://github.com/bronsk1y/Kaz.Operations.Text.Tokenizing).
