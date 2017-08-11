using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Interface
{
    public interface IInterfaceWithConstructor<T> where T : new()
    {
        int Add(int one, int two);
    }

    public class Example_4 : IInterfaceWithConstructor<Example_4>
    {

        public Example_4()
        {

        }

        public Example_4(string name)
        {

        }

        #region IInterfaceWithConstructor<Example_4> Members

        public int Add(int one, int two)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
