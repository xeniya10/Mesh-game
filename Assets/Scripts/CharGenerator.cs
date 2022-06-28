using UnityEngine;

public static class CharGenerator
{
    private static int _minCharNumber = 65;
    private static int _maxCharNumber = 90;

    public static char Generate()
    {
        var randomChar = (char)Random.Range(_minCharNumber, _maxCharNumber);
        return randomChar;
    }
}