﻿using System.Collections.Generic;
using Markdown.Html;
using Markdown.Tokens;

namespace Markdown
{
    public class MarkdownProcessor
    {
        private readonly HtmlConverter htmlConverter;

        public MarkdownProcessor()
        {
            htmlConverter = new HtmlConverter(new Dictionary<string, HtmlTag>
            {
                {"_", HtmlTag.Italic },
                {"__", HtmlTag.Bold }
            });
        }

        public string RenderToHtml(string markdownText)
        {
            var tokens = GetAllTokens(markdownText);
            return ReplaceTokensToHtmlInText(markdownText, tokens);
        }

        private IEnumerable<TwoSeparatorToken> GetAllTokens(string text)
        {
            return new TokenReader(text).ReadAllTwoSeparatorTokens(MarkdownSeparatorHandler.IsSeparator,
                MarkdownSeparatorHandler.GetSeparator, MarkdownSeparatorHandler.IsSeparatorValid);
        }

        private string ReplaceTokensToHtmlInText(string text, IEnumerable<TwoSeparatorToken> tokens)
        {
            var htmlText = text;
            foreach (var token in tokens)
            {
                var tokenValueInHtml = htmlConverter.ConvertSeparatedStringToHtmlString(token.Value, token.Separator);
                htmlText = htmlText.Replace(token.ValueWithSeparators, tokenValueInHtml);
            }

            return htmlText;
        }
    }
}