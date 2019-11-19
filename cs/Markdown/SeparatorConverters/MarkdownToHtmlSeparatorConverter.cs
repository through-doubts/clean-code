﻿using System;

namespace Markdown.SeparatorConverters
{
    public class MarkdownToHtmlSeparatorConverter : ISeparatorConverter
    {
        public string ConvertSeparator(string separator, string value)
        {
            switch (separator)
            {
                case "_":
                    return ApplyPairedHtmlTagTo(value, "em");
                default:
                    throw new NotImplementedException();
            }
        }

        private string ApplyPairedHtmlTagTo(string value, string tag)
        {
            return $"<{tag}>{value}</{tag}>";
        }
    }
}