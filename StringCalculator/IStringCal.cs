namespace StringCalculator
{
    //StringCal can only accessed via this interface
    public interface IStringCal
    {
        int Operation(string operand, string input);
    }
}
