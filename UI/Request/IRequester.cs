using System;
using System.Collections;
using System.Collections.Generic;
namespace UI.Request
{
    public interface IRequester
    {
        string Request(string message);

        T Request<T>(string message);

        TOut Request<T, TOut>(string message, Func<T, TOut> customCast);

        bool YNQuestionKey(string message);

        T Chooser<T>(IList<T> root);

        T Chooser<T>(IList<T> root, Func<T, string> customToString);
    }
}