using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1wpf
{
    public class Stos
    {
        private List<String> sztos = new List<String>();

        public void Push(String item)
        {
            if (item != "")
            sztos.Add(item);
        }

        public void Pop()
        {
            if(!Empty())
            sztos.RemoveAt(sztos.Count - 1);
        }

        public String Top()
        {
            if (Empty()) return "brak";
            return sztos[sztos.Count - 1];
        }

        public Boolean Empty()
        {
            if (sztos.Count == 0)
                return true;
            return false;
        }

    }
}
