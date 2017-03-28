using System.Collections.Generic;

namespace CSharpFSharpTranslate
{
    public class Node : ITree
    {
        private int value;
        private List<ITree> nodes;
    }
}