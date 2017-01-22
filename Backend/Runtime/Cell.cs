using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Runtime
{
    public class Cell: ICell
    {
        private Object value = null;

        public Cell(object value)
        {
            this.value = value;
        }


        public void SetValue(object newValue)
        {
            this.value = newValue;
        }

        public object GetValue()
        {
            return value;
        }
    }

    public interface ICell
    {
        void SetValue(Object newValue);

        Object GetValue();
    }
}
