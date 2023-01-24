using System.Text.RegularExpressions;

public class UrlParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object? value)
    {
        if (value is not string url) return string.Empty;

        return Regex.Replace(url, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                "-$1",
                RegexOptions.Compiled)
                .Trim()
                .ToLower();
    }
}

//"([a-z])([A-Z])", "$1-$2").ToLower();