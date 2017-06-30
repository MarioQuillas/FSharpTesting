using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFSharpTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            var toto = Observable.Return(42);
            toto.Subscribe(x => { }, x => { }, () => { });

            toto.Subscribe
            (
                x => Console.WriteLine("OnNext: {0}", x),
                ex => Console.WriteLine("OnError: {0}", ex),
                () => Console.WriteLine("OnCompleted")
            );

        }
    }
}
