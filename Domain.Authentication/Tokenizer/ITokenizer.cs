namespace Domain.Authentication.Tokenizer;

public interface ITokenizer<T> where T : class
{

    public static string TOKEN_NAME => "token_auth";
    string GenerateToken(T t);
}